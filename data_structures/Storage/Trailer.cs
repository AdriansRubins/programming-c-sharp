using data_structures.Operational;

namespace data_structures.Storage;

public class Trailer
{
    private Pallet[][] _pallets;

    public Trailer()
    {
        _pallets = new Pallet[Configuration.TrailerSize[0]][];
        for (var i = 0; i < Configuration.TrailerSize[1]; i++)
        {
            _pallets[i] = new Pallet[Configuration.TrailerSize[1]];
        }
    }
}