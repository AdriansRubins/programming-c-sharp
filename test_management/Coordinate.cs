namespace test_management;

public class Coordinate
{
    private readonly double _latitude;
    private readonly double _longitude;
    private readonly string _city;

    public Coordinate(double latitude, double longitude, string city)
    {
        _latitude = latitude;
        _longitude = longitude;
        _city = city;
    }

    public double GetLatitude()
    {
        return _latitude;
    }

    public double GetLongitude()
    {
        return _longitude;
    }

    public string GetCity()
    {
        return _city;
    }
}