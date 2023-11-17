namespace test_management;

public class Airplane
{
    private readonly Wing _leftWing;
    private readonly Wing _rightWing;
    private readonly CargoSpace _cargoSpace;
    private readonly FlightManagement _flightManagement;

    private Airplane(Builder builder)
    {
        _leftWing = builder.LeftWing;
        _rightWing = builder.RightWing;
        _cargoSpace = builder.CargoSpace;
        _flightManagement = builder.FlightManagement;
    }

    public Wing GetLeftWing()
    {
        return _leftWing;
    }

    public Wing GetRightWing()
    {
        return _rightWing;
    }

    public CargoSpace GetCargoSpace()
    {
        return _cargoSpace;
    }

    public FlightManagement GetFlightManagement()
    {
        return _flightManagement;
    }

    public void EngineStartup()
    {
        foreach (var engine in _leftWing.GetEngineList()) engine.Startup();

        foreach (var engine in _rightWing.GetEngineList()) engine.Startup();
    }

    public void SetSpeed(int speed)
    {
        foreach (var engine in _leftWing.GetEngineList()) engine.SetRpm(speed * Configuration.SpeedRpmFactor);
        
        foreach (var engine in _rightWing.GetEngineList()) engine.SetRpm(speed * Configuration.SpeedRpmFactor);
    }
    
    public void EngineShutdown()
    {
        foreach (var engine in _leftWing.GetEngineList()) engine.Shutdown();

        foreach (var engine in _rightWing.GetEngineList()) engine.Shutdown();
    }

    public class Builder
    {
        internal readonly Wing LeftWing;
        internal readonly Wing RightWing;
        internal readonly CargoSpace CargoSpace;
        internal readonly FlightManagement FlightManagement;

        public Builder(int numberOfEnginesPerWing)
        {
            LeftWing = new Wing(Position.Port, new NavigationLight(NavigationLightColor.Red));
            RightWing = new Wing(Position.Starboard, new NavigationLight(NavigationLightColor.Green));

            for (var i = 0; i < numberOfEnginesPerWing; i++)
            {
                LeftWing.AddFan(new Engine());
                RightWing.AddFan(new Engine());
            }

            CargoSpace = new CargoSpace();
            FlightManagement = new FlightManagement();
        }
        
        public Airplane Build()
        {
            return new Airplane(this);
        }
    }
}