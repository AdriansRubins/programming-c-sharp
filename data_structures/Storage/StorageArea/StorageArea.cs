namespace data_structures.Storage.StorageArea;

public class StorageArea<T, TU> where T : IStorage<TU>
{
    private StorageLocation<T, TU>?[][]? _storageLocations;
    private readonly StorageAreaTyp _storageAreaTyp;

    public StorageArea(StorageAreaTyp storageAreaTyp)
    {
        _storageAreaTyp = storageAreaTyp;
        InitiateStorageSections();
    }

    private void InitiateStorageSections()
    {
        switch (_storageAreaTyp)
        {
            case StorageAreaTyp.Box:
                FillStorageSections(Configuration.StorageSectionSizeBoxes);
                break;
            case StorageAreaTyp.Pallet:
                FillStorageSections(Configuration.StorageSectionSizePallets);
                break;
        }
    }

    private void FillStorageSections(int storageSectionSize)
    {
        _storageLocations = new StorageLocation<T, TU>[storageSectionSize][];
        for (var i = 0; i < _storageLocations.Length; i++)
        {
            _storageLocations[i] = new StorageLocation<T, TU>[storageSectionSize];
            for (var j = 0; j < _storageLocations[i].Length; j++)
            {
                _storageLocations[i][j] = new StorageLocation<T, TU>();
            }
        }
    }
}