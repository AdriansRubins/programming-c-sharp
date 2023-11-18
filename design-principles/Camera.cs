using Implementation.Hardware;
using Implementation.Memory;


namespace Implementation;

public class Camera : ICamera
{
    private string _serialNumber;
    private bool _isOn;
    private List<IRLed> _irLeds;
    private Chip[] _chips;

    private Camera(Builder builder)
    {
        _serialNumber = builder._serialNumber;
        _isOn = builder._isOn;
        _irLeds = builder._irLeds;
        _chips = builder._chips;
        MemoryCard = builder.MemoryCard;
    }

    public bool IsOn
    {
        get => _isOn;
    }

    public IMemoryCardStrategy MemoryCard { get; set; }

    public void VoiceCommand()
    {
        string _command;
        Console.WriteLine("Enter Command: ");
        _command = Console.ReadLine();

        switch (_command)
        {
            case "turnOn" or "Activate" or "On":
                turnOn();
                break;
            case "turnOff" or "Deactivate" or "Off":
                turnOff();
                break;
            default:
                Console.WriteLine("Unknown Command, try 'On' or 'Off'");
                break;
        }
    }

    public void turnOn()
    {
        _isOn = true;
    }

    public void turnOff()
    {
        _isOn = false;
    }

    public char[,] getRawFacePicture(int faceId)
    {
        string path;
        if (faceId > 10)
        {
            path = $"../../../../solid_data/face{faceId}.txt";
        }
        else
        {
            path = $"../../../../solid_data/face0{faceId}.txt";
        }

        string[] file = File.ReadAllLines(path);
        char[,] content = new char[21, 14];

        for (int i = 0; i < file.Length; i++)
        {
            for (int j = 0; j < file[i].Length; j++)
            {
                content[i, j] = file[i][j];
            }
        }

        return content;
    }

    public int[] extractFace(char[,] content)
    {
        int[] coordinates = new int[4];

        //search for first x
        for (int y = 0; y < 21; y++)
        {
            for (int x = 0; x < 14; x++)
            {
                if (content[y, x] == '+')
                {
                    coordinates[0] = y;
                    coordinates[1] = x;
                    goto EndFirst;
                }
            }
        }

        EndFirst:


        //search for last x
        for (int y = 21 - 1; y >= 0; y--)
        {
            for (int x = 14 - 1; x >= 0; x--)
            {
                if (content[y, x] == '+')
                {
                    coordinates[2] = y;
                    coordinates[3] = x;
                    goto EndSec;
                }
            }
        }

        EndSec:
        return coordinates;
    }


    public Picture getFaceArea(int faceId, char[,] face, int[] area)
    {
        char[,] content = new char[10, 10];
        int contentX = 0;
        int contentY = 0;


        //iterate over the face char array
        for (int y = area[0]; y < (area[2] + 1); y++)
        {
            for (int x = (area[1] + 1); x < area[3]; x++)
            {
                content[contentY, contentX] = face[y, x];
                contentX++;
            }

            contentX = 0;
            contentY++;
        }

        return new Picture(faceId, content);
    }

    public void savePictureOnMemory(int faceId)
    {
        var content = getRawFacePicture(faceId);

        MemoryCard.SavePicture(getFaceArea(faceId, content, extractFace(content)));
    }

    public class Builder
    {
        internal string _serialNumber;
        internal bool _isOn;
        internal List<IRLed> _irLeds;
        internal Chip[] _chips;
        internal IMemoryCardStrategy MemoryCard;


        public Builder(CPUType cputype, IMemoryCardStrategy memoryCardStrategy)
        {
            _serialNumber = "Z7HJ8A1";
            _isOn = false;
            _irLeds = new List<IRLed>();

            MemoryCard = memoryCardStrategy;


            for (int i = 0; i < 24; i++)
            {
                _irLeds.Add(new IRLed());
            }

            if (cputype == CPUType.DualCore)
            {
                _chips = new Chip[2];
                _chips[0] = new DualCoreChip();
                _chips[1] = new DualCoreChip();
            }

            if (cputype == CPUType.QuadCore)
            {
                _chips = new Chip[4];
                for (int i = 0; i < _chips.Length; i++)
                {
                    _chips[i] = new QuadCoreChip();
                }
            }
        }

        public Camera build()
        {
            return new Camera(this);
        }
    }
}