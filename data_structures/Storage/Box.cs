#nullable disable

namespace data_structures.Storage;

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

        InitiateContainer();
    }


    public void StoreItem(Orange item)
    {
        foreach (var oranges in _oranges)
        foreach (var row in _oranges)
        {
            for (var j = 0; j < oranges.Length; j++)
            for (var i = 0; i < row.Length; i++)
            {
                if (oranges[j] is not Orange) continue;
                oranges[j] = item;
                if (row[i] != null) continue;
                row[i] = item;
                return;
            }
        }
    }

    public bool IsEmpty()
    {
        return _oranges.SelectMany(oranges => oranges).All(orange => orange == null);
    }

    private static int GetRowCapacity(int row)
    {
        return row % 2 == 0 ? 4 : 5;
    }

    public void InitiateContainer()
    {
        for (var i = 0; i < _oranges.Length; i++)
        {
            _oranges[i] = new Orange[GetRowCapacity(i)];
        }
    }
}