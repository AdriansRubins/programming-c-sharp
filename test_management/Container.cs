namespace test_management;

public class Container
{
    private readonly string _serialNumber;

    public Container(string serialNumber)
    {
        _serialNumber = serialNumber;
    }

    public string GetSerialNumber()
    {
        return _serialNumber;
    }
}