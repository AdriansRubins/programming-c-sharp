#nullable disable

namespace data_structures.Storage;

public class Pallet : IStorage<Box>
{
    private Box[][][] _boxes;

    public Pallet()
    {
        _boxes = new Box[4][][];
        InitiateContainer();
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

    public bool IsEmpty()
    {
        return _boxes.SelectMany(boxes => boxes).SelectMany(boxes => boxes).All(box => box == null);
    }

    public void InitiateContainer()
    {
        _boxes = Enumerable.Range(0, 4)
            .Select(_ => Enumerable.Range(0, 3)
                .Select(_ => Enumerable.Range(0, 4)
                    .Select(_ => new Box())
                    .ToArray())
                .ToArray())
            .ToArray();
    }
}