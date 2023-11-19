#nullable disable

using data_structures.Operational;

namespace data_structures.Storage;

public class Box : IStorage<Orange>
{
    private readonly Orange[][] _oranges;
    private static readonly int[] RowCapacities = { 4, 5, 4, 5 };

    public Box()
    {
        _oranges = new Orange[4][];
        for (var i = 0; i < 4; i++)
        {
            _oranges[i] = new Orange[RowCapacities[i]];
        }
    }

    public void StoreItem(Orange item)
    {
        for (var i = 0; i < _oranges.Length; i++)
        {
            for (var j = 0; j < _oranges[i].Length; j++)
            {
                if (_oranges[i][j] != null) continue;
                _oranges[i][j] = item;
                return;
            }
        }
    }

    public bool IsFull()
    {
        return _oranges.All(row => row.All(orange => orange != null));
    }
}