namespace Ch14_Appendix.Flyweight;

public sealed class Tree
{
    private readonly int _x;
    private readonly int _y;
    private readonly TreeType _type;

    public Tree(int x, int y, TreeType type)
    {
        _x = x;
        _y = y;
        _type = type;
    }

    public void Draw() 
        => Console.WriteLine($"Drawing {_type.Name} at ({_x}, {_y}) with {_type.Color} leaves.");
}
