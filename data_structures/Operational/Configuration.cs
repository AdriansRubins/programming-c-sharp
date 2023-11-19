namespace data_structures.Operational;

internal static class Configuration
{
    public const int MaxOrangesInQueue = 31104;
    public const int MinOrangeWeight = 140;
    public const int MaxOrangeWeight = 160;
    public static readonly int[]? MaxBoxRowsCapacity = { 4, 5, 4, 5 };
    public static readonly int[]? StorageSectionSizeBoxes = { 3, 3 };
    public static readonly int[]? StorageSectionSizePallets = { 8, 8 };
    public static readonly int[]? BoxesInPallet = { 4, 3, 4 };
    public static readonly int[] TrailerSize = { 3, 12 };
    public static int InitialEmptyBoxesInStorageArea = 1920;
    public static int InitialEmptyPalletsInStorageArea = 36;
    public static int MaxBoxesInStorageLocation = 30;
    public static int MaxPalletsInStorageLocation = 4;
}