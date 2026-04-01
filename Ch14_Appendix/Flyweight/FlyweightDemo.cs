namespace Ch14_Appendix.Flyweight;

public static class FlyweightDemo
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("--- Flyweight Pattern ---");

        var factory = new TreeTypeFactory();
        var forest = new List<Tree>
        {
            new(10, 20, factory.GetTreeType("Oak", "Green")),
            new(15, 25, factory.GetTreeType("Oak", "Green")),
            new(30, 40, factory.GetTreeType("Pine", "Dark Green"))
        };

        foreach (Tree tree in forest)
        {
            tree.Draw();
        }

        Console.WriteLine($"Unique flyweights created: {factory.Count}");
    }
}
