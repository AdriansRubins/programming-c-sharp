namespace Implementation.Memory;

public class MemoryCard
{
    private Stack<Picture> _store;
    
    public Stack<Picture> Store
    {
        get => _store;
    }

    public MemoryCard()
    {
        _store = new Stack<Picture>();
    }

    public void savePicture(Picture picture)
    {
        _store.Push(picture);
    }
    
    
    
    public Picture getPicture()
    {
        return _store.Pop();
    }
    
}