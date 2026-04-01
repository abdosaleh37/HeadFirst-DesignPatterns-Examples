namespace Ch14_Appendix.Visitor;

public sealed class Electronics : ICartElement
{
    public Electronics(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public string Name { get; }
    public decimal Price { get; }

    public decimal Accept(ICartVisitor visitor) => visitor.Visit(this);
}
