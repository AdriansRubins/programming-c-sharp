namespace Implementation.Memory;

public class DictionaryMemoryCard : IMemoryCardStrategy
{
    private readonly Dictionary<int, Picture> _store;

    public Dictionary<int, Picture> Store => _store;

    public DictionaryMemoryCard()
    {
        _store = new Dictionary<int, Picture>();
    }

    public void SavePicture(Picture picture)
    {
        _store.Add(picture.GetHashCode(), picture);
    }

    public Picture GetPicture()
    {
        _store.Remove(_store.Last().Key);
        return _store.Last().Value;
    }
}