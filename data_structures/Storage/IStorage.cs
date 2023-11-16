namespace data_structures.Storage;

public interface IStorage<in T>
{
    void StoreItem(T item);
    bool IsEmpty();
    void InitiateContainer();
}