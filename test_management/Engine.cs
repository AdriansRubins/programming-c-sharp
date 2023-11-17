namespace test_management;

using System.Collections.Generic;

public class Engine : IEngine
{
    private Wing? _wing;
    private readonly List<Blade> _blades;
    private bool _isStarted;
    private int _rpm;

    public Engine()
    {
        _blades = new List<Blade>();

        for (var i = 0; i < 48; i++) _blades.Add(new Blade());
    }

    public void SetWing(Wing? wing)
    {
        _wing = wing;
    }
    
    public bool IsStarted()
    {
        return _isStarted;
    }

    public void SetStarted(bool started)
    {
        _isStarted = started;
    }

    public int GetRpm()
    {
        return _rpm;
    }

    public void SetRpm(int rpm)
    {
        _rpm = rpm;
    }

    public List<Blade> GetBlades()
    {
        return new List<Blade>(_blades);
    }

    public void Startup()
    {
        _isStarted = true;
        PrimaryFlightDisplay.CountEnginesStarted++;

        for (var i = 0; i <= 25; i++)
        {
            _rpm++;
        }
    }

    public void SetOnFire()
    {
        _wing?.GetExtinguishingSystem().Activate();
    }
    
    public void Shutdown()
    {
        PrimaryFlightDisplay.CountEnginesStarted--;
        
        for (var i = 0; i <= _rpm; i++)
        {
            _rpm--;
        }

        _isStarted = false;
    }
}