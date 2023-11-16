namespace data_structures;

public class OrangeQueue
{
    private readonly Queue<Orange> _oranges;

    public OrangeQueue()
    {
        _oranges = new Queue<Orange>(Configuration.MaxOrangesInQueue);
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