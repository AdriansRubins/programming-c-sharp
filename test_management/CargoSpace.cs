using System.Collections;

namespace test_management;

public class CargoSpace
{
    private readonly Stack _left = new();
    private readonly Stack _right = new();

    public void Load()
    {
        _left.Push(new Container("FIT4PHL6OB"));
        _left.Push(new Container("YBISIUP2EZ"));
        _left.Push(new Container("5FUVILAYL4"));
        _left.Push(new Container("5I8PJF47ZY"));
        _left.Push(new Container("9GA14TSTNN"));
        _left.Push(new Container("QOO5RGZ33T"));
        _left.Push(new Container("WAH8HN0Q3A"));
        _left.Push(new Container("E8SU18XZDK"));

        _right.Push(new Container("1QKQNPHXJK"));
        _right.Push(new Container("DPB4M7BO1A"));
        _right.Push(new Container("AG2WG00YL1"));
        _right.Push(new Container("BR94D8UN95"));
        _right.Push(new Container("SJI469GG6P"));
        _right.Push(new Container("N1KUAMAWX3"));
        _right.Push(new Container("RX73QQ78JY"));
        _right.Push(new Container("YB9RCIK1MF"));
    }

    public Stack GetLeft()
    {
        return _left;
    }

    public Stack GetRight()
    {
        return _right;
    }
}