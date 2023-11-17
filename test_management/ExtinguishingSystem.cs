namespace test_management;

public class ExtinguishingSystem
{
    private readonly ExtinguishingSystemTank _tank = new ExtinguishingSystemTank(false);
    private bool _isActive;

    public ExtinguishingSystemTank GetExtinguishingSystemTank()
    {
        return _tank;
    }
    
    public bool IsActive()
    {
        return _isActive;
    }

    public void Activate()
    {
        if (_tank.IsEmpty()) return;
        _isActive = true;
        _tank.Empty();
        PrimaryFlightDisplay.CountCallExtinguishFire++;
    }

    public void Deactivate()
    {
        _isActive = false;
    }
}