namespace Implementation.Memory;

public class Picture
{
    private int _faceID;
    private char[,] _content;
    private string _timeStamp;

    public Picture(int faceId, char[,] content)
    {
        _content = new char[21, 14];
        
        _faceID = faceId;
        _content = content;
        _timeStamp = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
    }
    
    public char[,] Content
    {
        get => _content;
    }

    public string Timestamp
    {
        get => _timeStamp;
    }
    
}