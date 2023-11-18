namespace Implementation.Memory;

public class DictionaryMemoryCard : IMemoryCardStrategy
{
    private Dictionary<string, Picture> Store { get; }

    public DictionaryMemoryCard()
    {
        Store = new Dictionary<string, Picture>();
    }

    public void SavePicture(Picture picture)
    {
        Store.Add(picture.Timestamp, picture);
    }

    public Picture GetPicture()
    {
        var picture = Store.Last().Value;
        Store.Remove(Store.Last().Key);
        return picture;
    }
    
    public Picture GetPicture(string timestamp)
    {
        var picture = Store.Last().Value;
        Store.Remove(timestamp);
        return picture;
    }
}