namespace Ch14_Appendix.Interpreter;

public interface IExpression
{
    bool Interpret(IReadOnlyDictionary<string, bool> context);
}
