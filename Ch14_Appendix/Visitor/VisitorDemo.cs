namespace Ch14_Appendix.Visitor;

public static class VisitorDemo
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("--- Visitor Pattern ---");

        ICartElement[] items =
        [
            new Book("Design Patterns", 45m),
            new Electronics("Headphones", 120m)
        ];

        ICartVisitor visitor = new PriceVisitor();
        decimal total = items.Sum(item => item.Accept(visitor));

        Console.WriteLine($"Total cart price: {total:C}");
    }
}
