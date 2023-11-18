namespace Implementation.Hardware;

public class IRLed
{
    private readonly int _brightness;
    
    public int Brightness
    {
        get => _brightness;
    }

    public IRLed()
    {
        _brightness = 3;
    }
    
}