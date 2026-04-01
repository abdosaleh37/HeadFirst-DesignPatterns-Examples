namespace Ch14_Appendix.Flyweight;

public sealed class TreeType
{
    public TreeType(string name, string color)
    {
        Name = name;
        Color = color;
    }

    public string Name { get; }
    public string Color { get; }
}
