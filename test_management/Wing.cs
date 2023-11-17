namespace test_management;

using System.Collections.Generic;

public class Wing
{
    private readonly Position _position;
    private readonly NavigationLight _navigationLight;
    private readonly List<Engine> _engineList;
    private readonly ExtinguishingSystem _extinguishingSystem;

    public Wing(Position position, NavigationLight navigationLight)
    {
        _position = position;
        _navigationLight = navigationLight;
        _engineList = new List<Engine>();
        _extinguishingSystem = new ExtinguishingSystem();
    }

    public List<Engine> GetEngineList()
    {
        return _engineList;
    }

    public void AddFan(Engine engine)
    {
        engine.SetWing(this);
        _engineList.Add(engine);
    }

    public Position GetPosition()
    {
        return _position;
    }

    public NavigationLight GetNavigationLight()
    {
        return _navigationLight;
    }

    public ExtinguishingSystem GetExtinguishingSystem()
    {
        return _extinguishingSystem;
    }
}