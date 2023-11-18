namespace Implementation.Memory;

public class StackMemoryCard : IMemoryCardStrategy
{
    private Stack<Picture> Store { get; }

    public StackMemoryCard()
    {
        Store = new Stack<Picture>();
    }

    public void SavePicture(Picture picture)
    {
        Store.Push(picture);
    }


    public Picture GetPicture()
    {
        return Store.Pop();
    }
}