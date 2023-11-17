namespace test_management;

public class NavigationLight
{
    private readonly NavigationLightColor _color;

    public NavigationLight(NavigationLightColor color)
    {
        _color = color;
    }

    public NavigationLightColor GetColor()
    {
        return _color;
    }
}