namespace data_structures;

public interface IStorage<in T>
{
    void StoreItem(T item);
    bool IsEmpty();
    void InitiateContainer();
}