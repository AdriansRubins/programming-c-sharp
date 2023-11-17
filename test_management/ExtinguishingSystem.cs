namespace test_management;

public class ExtinguishingSystem
{
    private bool _isActive;

    public bool IsActive()
    {
        return _isActive;
    }

    public void Activate()
    {
        _isActive = true;
    }

    public void Deactivate()
    {
        _isActive = false;
    }
}