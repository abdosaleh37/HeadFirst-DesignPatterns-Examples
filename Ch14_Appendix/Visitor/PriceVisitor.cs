namespace Ch14_Appendix.Visitor;

public sealed class PriceVisitor : ICartVisitor
{
    public decimal Visit(Book book)
    {
        decimal discounted = book.Price * 0.95m;
        Console.WriteLine($"Book '{book.Title}' with 5% discount: {discounted:C}");
        return discounted;
    }

    public decimal Visit(Electronics electronics)
    {
        decimal taxed = electronics.Price * 1.10m;
        Console.WriteLine($"Electronics '{electronics.Name}' with 10% tax: {taxed:C}");
        return taxed;
    }
}
