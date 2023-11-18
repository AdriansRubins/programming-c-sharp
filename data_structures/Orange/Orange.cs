namespace data_structures;

public class Orange
{
    private static readonly Random Random = new();
    public int Weight;

    public Orange()
    {
        Weight = Random.Next(140, 161);
    }
}