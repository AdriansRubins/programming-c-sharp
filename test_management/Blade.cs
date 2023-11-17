namespace test_management;

public class Blade
{
    private readonly Guid _serialNumber = Guid.NewGuid();

    public Guid GetSerialNumber()
    {
        return _serialNumber;
    }
}