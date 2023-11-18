using Implementation;
using Implementation.Hardware;
using Implementation.Memory;

var message = "Welcome";
Console.WriteLine(message);

Camera camera = new Camera.Builder(CPUType.QuadCore).build();

camera.savePictureOnMemory(1);

Picture pic = camera.MemoryCard.getPicture();

string[] strings = new string[10];

for (int i = 0; i < 10; i++)
{
    char[] chars = new char[10];
    
    for (int j = 0; j < 10; j++)
    {
        chars[j] = pic.Content[i, j];
    }

    strings[i] = new string(chars);
}

foreach (var item in strings)
{
    Console.WriteLine(item);
}

Console.ReadKey();

camera.VoiceCommand();

