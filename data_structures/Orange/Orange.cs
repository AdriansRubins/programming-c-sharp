namespace data_structures.Orange;

public class Orange
{
    private static readonly Random Random = new();
    public int Weight { get; } = Random.Next(140, 161);
}