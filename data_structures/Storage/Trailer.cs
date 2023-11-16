using data_structures.Operational;

namespace data_structures.Storage;

public class Trailer
{
    private Pallet[][]? _pallets;

    public Trailer()
    {
        InitiatePallets();
    }

    private void InitiatePallets()
    {
        _pallets = new Pallet[Configuration.TrailerSize[0]][];
        for (var i = 0; i < Configuration.TrailerSize[0]; i++)
        {
            _pallets[i] = new Pallet[Configuration.TrailerSize[1]];
            for (var j = 0; j < Configuration.TrailerSize[1]; j++)
            {
                _pallets[i][j] = new Pallet();
            }
        }
    }
}