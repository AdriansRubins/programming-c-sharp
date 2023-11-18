using data_structures.Operational;

namespace data_structures.Storage.StorageArea;

public class StorageArea<T, TU> where T : IStorage<TU>
{
    private StorageLocation<T, TU>?[][]? _storageLocations;
    private readonly StorageAreaTyp _storageAreaTyp;
    private int[] _storageSectionSize;

    public StorageArea(StorageAreaTyp storageAreaTyp)
    {
        _storageAreaTyp = storageAreaTyp;
        switch (_storageAreaTyp)
        {
            case StorageAreaTyp.Box:
                if (Configuration.StorageSectionSizeBoxes != null)
                    _storageSectionSize = Configuration.StorageSectionSizeBoxes;
                break;
            case StorageAreaTyp.Pallet:
                if (Configuration.StorageSectionSizePallets != null)
                    _storageSectionSize = Configuration.StorageSectionSizePallets;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        InitiateStorageLocations();
    }

    private void InitiateStorageLocations()
    {
        FillStorageSections();
    }

    public void FillStorageSections()
    {
        _storageLocations = new StorageLocation<T, TU>[_storageSectionSize[0]][];
        for (var i = 0; i < _storageLocations.Length; i++)
        {
            _storageLocations[i] = new StorageLocation<T, TU>?[_storageSectionSize[1]];
            for (var j = 0; j < _storageLocations[i].Length; j++)
            {
                _storageLocations[i][j] = new StorageLocation<T, TU>();
            }
        }
    }
}