namespace test_management;

public class Tests
{
    private Airplane? _airplane;

    [SetUp]
    public void Setup()
    {
        _airplane = new Airplane.Builder(2).Build()!;
        _airplane?.GetCargoSpace().Load();
    }

    [Test]
    public void AirplaneIsCompletelyBuilt()
    {
        var airplane = new Airplane.Builder(48).Build();
        Assert.Multiple(() =>
        {
            Assert.That(airplane!.GetLeftWing(), Is.Not.Null);
            Assert.That(airplane.GetRightWing(), Is.Not.Null);
            Assert.That(airplane.GetLeftWing().GetExtinguishingSystem(), Is.Not.Null);
        });
        Assert.Multiple(() =>
        {
            Assert.That(airplane.GetRightWing().GetExtinguishingSystem(), Is.Not.Null);
            Assert.That(airplane.GetCargoSpace(), Is.Not.Null);
            Assert.That(airplane.GetFlightManagement(), Is.Not.Null);
            Assert.That(airplane.GetLeftWing().GetEngineList(), Is.Not.Null);
        });
        Assert.That(airplane.GetLeftWing().GetEngineList(), Is.Not.Null);
    }

    [Test]
    public void NavigationLightsAreCorrectlyPositioned()
    {
        var airplane = new Airplane.Builder(48).Build();
        Assert.Multiple(() =>
        {
            Assert.That(airplane!.GetLeftWing().GetNavigationLight().GetColor(), Is.EqualTo(NavigationLightColor.Red));
            Assert.That(airplane.GetRightWing().GetNavigationLight().GetColor(),
                Is.EqualTo(NavigationLightColor.Green));
        });
    }

    [Test]
    public void NumberOfEnginesIsCorrect()
    {
        var airplane = new Airplane.Builder(48).Build();
        Assert.Multiple(() =>
        {
            Assert.That(airplane!.GetLeftWing().GetEngineList(), Has.Count.EqualTo(48));
            Assert.That(airplane.GetRightWing().GetEngineList(), Has.Count.EqualTo(48));
        });
    }

    [Test]
    public void CargoSpaceLoadingIsCorrect()
    {
        var airplane = new Airplane.Builder(48).Build();
        airplane!.GetCargoSpace().Load();
        Assert.Multiple(() =>
        {
            Assert.That(airplane.GetCargoSpace().GetLeft().ToArray().All(left => left == null), Is.True);
            Assert.That(airplane.GetCargoSpace().GetRight().ToArray().All(left => left == null), Is.True);
        });
    }

    [Test]
    public void EngineStartupStartsAllEngines()
    {
        var airplane = new Airplane.Builder(48).Build();
        airplane!.EngineStartup();
        Assert.Multiple(() =>
        {
            Assert.That(airplane.GetLeftWing().GetEngineList().All(e => e.IsStarted()));
            Assert.That(airplane.GetRightWing().GetEngineList().All(e => e.IsStarted()));
        });
    }

    //TODO: Do the math, find the correct rpm values SpeedRpmFactor
    [Test]
    public void EnginesGenerateCorrectRpm()
    {
        var airplane = new Airplane.Builder(48).Build();
        var speeds = new[] { 0, 25, 70, 165, 300, 371, 455, 500 };

        foreach (var speed in speeds)
        {
            airplane.SetSpeed(speed);
            foreach (var engine in airplane.GetLeftWing().GetEngineList())
            {
                Assert.That(engine.GetRpm(), Is.EqualTo(speed * Configuration.SpeedRpmFactor));
            }

            foreach (var engine in airplane.GetRightWing().GetEngineList())
            {
                Assert.That(engine.GetRpm(), Is.EqualTo(speed * Configuration.SpeedRpmFactor));
            }
        }
    }

    //TODO: Test number of calls??? Mocking?
    [Test]
    public void EngineShutdownSwitchesOffAllEngines()
    {
        var airplane = new Airplane.Builder(48).Build();
        var initialCount = PrimaryFlightDisplay.CountEnginesStarted;
        airplane!.EngineStartup();
        Assert.That(PrimaryFlightDisplay.CountEnginesStarted, Is.EqualTo(initialCount + 48 * 2));
        airplane.EngineShutdown();
        Assert.That(PrimaryFlightDisplay.CountEnginesStarted, Is.EqualTo(initialCount - 48 * 2));
    }


    //TODO: It does need an update in code, because there is no extinguishFire()
    [Test]
    public void ExtinguishFireWorksCorrectly()
    {
        var airplane = new Airplane.Builder(48).Build();
        var engine = airplane.GetLeftWing().GetEngineList().First();
        engine.Startup();
        engine.SetRpm(20000);
        airplane.GetLeftWing().GetExtinguishingSystem().Activate();
        Assert.That(engine.GetRpm(), Is.LessThanOrEqualTo(10000));
        Assert.That(airplane.GetLeftWing().GetExtinguishingSystem().IsActive(), Is.False);
        Assert.That(PrimaryFlightDisplay.CountCallExtinguishFire, Is.EqualTo(1));
    }

    [Test]
    public void MunichIsNotRegistered()
    {
        var airplane = new Airplane.Builder(48).Build();
        Assert.That(airplane.GetFlightManagement().Search("Munich"), Is.Null);
    }

    [Test]
    public void LondonIsRegistered()
    {
        var airplane = new Airplane.Builder(48).Build();
        Assert.That(airplane.GetFlightManagement().Search("London"), Is.Not.Null);
    }

    [Test]
    public void CorrectCoordinatesForLondon()
    {
        var airplane = new Airplane.Builder(48).Build();
        var coordinates = airplane!.GetFlightManagement().Search("London");
        Assert.That(coordinates, Is.EqualTo(new Coordinate(51.507351, -0.127758, "London")));
    }

    [Test]
    public void CorrectCityForCoordinates()
    {
        var airplane = new Airplane.Builder(48).Build();
        var city = airplane!.GetFlightManagement().Search(49.490200, 9.773150);
        Assert.That(city, Is.EqualTo("Bad Mergentheim"));
    }
}