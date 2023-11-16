using data_structures.Operational;

namespace data_structures.Orange;

public class OrangeQueue
{
    private readonly Queue<Orange> _oranges;

    public OrangeQueue()
    {
        _oranges = new Queue<Orange>(Configuration.MaxOrangesInQueue);
        FillQueue();
    }

    private void AddOrange(Orange orange)
    {
        _oranges.Enqueue(orange);
    }

    private Orange RemoveOrange()
    {
        return _oranges.Dequeue();
    }

    public void FillQueue()
    {
        for (int i = 0; i < Configuration.MaxOrangesInQueue; i++)
        {
            AddOrange(new Orange());
        }
    }
}