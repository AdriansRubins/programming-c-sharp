namespace test_management;

public class ExtinguishingSystemTank
{
    private bool _isEmpty;

    public ExtinguishingSystemTank(bool isEmpty)
    {
        _isEmpty = isEmpty;
    }

    public bool IsEmpty()
    {
        return _isEmpty;
    }

    public void Empty()
    {
        _isEmpty = true;
    }
}