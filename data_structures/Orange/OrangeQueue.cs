using data_structures.Operational;

namespace data_structures;

public class OrangeQueue
{
    private readonly Queue<Orange> _oranges;
    private int _orangesInQueue;

    public OrangeQueue()
    {
        _oranges = new Queue<Orange>(Configuration.MaxOrangesInQueue);
    }

    private void AddOrange(Orange orange)
    {
        _oranges.Enqueue(orange);
        _orangesInQueue++;
    }

    private Orange RemoveOrange()
    {
        if (_oranges.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        _orangesInQueue--;
        return _oranges.Dequeue();
    }

    public void FillQueue()
    {
        for (var i = 0; i < Configuration.MaxOrangesInQueue; i++)
        {
            AddOrange(new Orange());
        }
    }
}