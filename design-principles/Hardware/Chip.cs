namespace Implementation.Hardware;

public abstract class Chip
{
    private Guid _uuid;
    
    public Guid Uuid{ get => _uuid;}

    public Chip()
    {
        _uuid = Guid.NewGuid();
    }
}