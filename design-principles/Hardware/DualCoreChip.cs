namespace Implementation.Hardware;

public  class DualCoreChip : Chip
{
    private Core[] _cores;
    
    public DualCoreChip() :base()
    {
        _cores = new Core[2];
        _cores[0] = new Core();
        _cores[1] = new Core();
    }
    
    public Core[] Cores
    {
        get => _cores;
    }
    
    
}