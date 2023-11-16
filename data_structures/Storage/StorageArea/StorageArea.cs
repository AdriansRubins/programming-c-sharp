namespace data_structures.Storage.StorageArea;

public class StorageArea
{
    private StorageSection[][]? _storageSections;
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
        _storageSections = new StorageSection[storageSectionSize][];
        for (var i = 0; i < _storageSections.Length; i++)
        {
            _storageSections[i] = new StorageSection[storageSectionSize];
            for (var j = 0; j < _storageSections[i].Length; j++)
            {
                _storageSections[i][j] = new StorageSection();
            }
        }
    }
}