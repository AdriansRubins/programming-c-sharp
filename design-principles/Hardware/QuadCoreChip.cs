namespace Implementation.Hardware;

public  class QuadCoreChip : Chip
{
    private Core[] _cores;
    
    public QuadCoreChip() :base()
    {
        _cores = new Core[4];
        _cores.Initialize();
    }
    
    public Core[] Cores
    {
        get => _cores;
    }
    
    
}