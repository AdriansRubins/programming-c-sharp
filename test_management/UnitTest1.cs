namespace test_management;

public class Tests
{
    private Airplane? _airplane;

    [SetUp]
    public void Setup()
    {
        _airplane = new Airplane.Builder(2).Build();
        _airplane?.GetCargoSpace().Load();
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}