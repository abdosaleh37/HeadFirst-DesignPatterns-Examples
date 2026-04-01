namespace Ch14_Appendix.Visitor;

public interface ICartElement
{
    decimal Accept(ICartVisitor visitor);
}
