namespace data_structures;

public interface IStorage<T>
{
    void StoreItem(T item);
    bool IsEmpty();
}