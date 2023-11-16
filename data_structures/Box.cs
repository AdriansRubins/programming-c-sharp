namespace data_structures;

public class Box : IStorage<Orange>
{
    private readonly Orange[][] _oranges;
    private const int MaxRows = 4;
    private readonly int[] _rowCapacities = { 4, 5, 4, 5 };

    public Box()
    {
        _oranges = new Orange[MaxRows][];
        for (var i = 0; i < _oranges.Length; i++)
        {
            _oranges[i] = new Orange[_rowCapacities[i]];
        }
    }

    
    public void StoreItem(Orange item)
    {
        foreach (var oranges in _oranges)
        {
            for (var j = 0; j < oranges.Length; j++)
            {
                if (oranges[j] is not Orange) continue;
                oranges[j] = item;
                return;
            }
        }
    }

    public bool IsEmpty()
    {
        
    }

    private static int GetRowCapacity(int row)
    {
        return row % 2 == 0 ? 4 : 5;
    }
}