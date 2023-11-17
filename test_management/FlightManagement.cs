namespace test_management;

using System.Collections.Generic;

public class FlightManagement
{
    private readonly List<Coordinate?> _coordinates;

    public FlightManagement()
    {
        _coordinates = new List<Coordinate?>();
        Init();
    }

    public List<Coordinate?> GetCoordinates()
    {
        return _coordinates;
    }

    public Coordinate? Search(string city)
    {
        return _coordinates.FirstOrDefault(coordinate => coordinate != null && coordinate.GetCity().Equals(city));
    }

    public string? Search(double latitude, double longitude)
    {
        return _coordinates
            .Where(coordinate => coordinate != null && coordinate.GetLatitude() == latitude &&
                                 coordinate.GetLongitude() == longitude)
            .Select(coordinate => coordinate?.GetCity()).FirstOrDefault();
    }

    private void Init()
    {
        _coordinates.Add(new Coordinate(51.507351, -0.127758, "London"));
        _coordinates.Add(new Coordinate(34.052235, -118.243683, "Los Angeles"));
        _coordinates.Add(new Coordinate(49.351978, 9.145870, "Mosbach"));
        _coordinates.Add(new Coordinate(-33.924870, 18.424055, "Cape Town"));
        _coordinates.Add(new Coordinate(49.490200, 9.773150, "Bad Mergentheim"));
    }
}