#nullable disable

using data_structures.Operational;

namespace data_structures.Storage;

public class Pallet : IStorage<Box>
{
    private Box[][][] _boxes;

    public Pallet()
    {
        _boxes = new Box[Configuration.BoxesInPallet[0]][][];
        for (int i = 0; i < Configuration.BoxesInPallet[0]; i++)
        {
            _boxes[i] = new Box[Configuration.BoxesInPallet[1]][];
            for (int j = 0; j < Configuration.BoxesInPallet[1]; j++)
            {
                _boxes[i][j] = new Box[Configuration.BoxesInPallet[2]];
            }
        }
    }

    public void StoreItem(Box item)
    {
        foreach (var row in _boxes)
        {
            foreach (var column in row)
            {
                for (var i = 0; i < column.Length; i++)
                {
                    if (column[i] != null) continue;
                    column[i] = item;
                    return;
                }
            }
        }
    }

    public bool IsFull()
    {
        return _boxes.SelectMany(boxes => boxes).SelectMany(boxes => boxes).Any(box => box != null);
    }
}