namespace data_structures;

public class Orange
{
    private static readonly Random _random = new();
    public int Weight { get; }
    
    public Orange()
    {
        Weight = _random.Next(140, 161);
    }
}