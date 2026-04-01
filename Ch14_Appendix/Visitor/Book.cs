namespace Ch14_Appendix.Visitor;

public sealed class Book : ICartElement
{
    public Book(string title, decimal price)
    {
        Title = title;
        Price = price;
    }

    public string Title { get; }
    public decimal Price { get; }

    public decimal Accept(ICartVisitor visitor) => visitor.Visit(this);
}
