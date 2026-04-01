namespace Ch14_Appendix.Visitor;

public interface ICartVisitor
{
    decimal Visit(Book book);
    decimal Visit(Electronics electronics);
}
