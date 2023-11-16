namespace data_structures.Operational;

internal static class Configuration
{
    public const int MaxOrangesInQueue = 31104;
    public static readonly int[] StorageSectionSizeBoxes = { 3, 3 };
    public static readonly int[] StorageSectionSizePallets = { 8, 8 };
    public static readonly int[] TrailerSize = { 3, 12 };
    public const int InitialEmptyBoxesInStorageArea = 1920;
    public const int InitialEmptyPalletsInStorageArea = 36;
    public const int MaxBoxesInStorageLocation = 30;
    public const int MaxPalletsInStorageLocation = 4;
}