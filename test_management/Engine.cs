namespace test_management;

using System.Collections.Generic;

public class Engine : IEngine
{
    private readonly List<Blade> _blades;
    private bool _isStarted;
    private int _rpm;

    public Engine()
    {
        _blades = new List<Blade>();

        for (var i = 0; i < 48; i++) _blades.Add(new Blade());
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

        for (var i = 0; i <= 25; i++)
        {
            Thread.Sleep(50);
            _rpm++;
        }
    }

    public void Shutdown()
    {
        for (var i = 0; i <= _rpm; i++)
        {
            Thread.Sleep(50);
            _rpm++;
        }

        _isStarted = false;
    }
}