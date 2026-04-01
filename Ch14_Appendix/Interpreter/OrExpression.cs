namespace Ch14_Appendix.Interpreter;

public sealed class OrExpression : IExpression
{
    private readonly IExpression _left;
    private readonly IExpression _right;

    public OrExpression(IExpression left, IExpression right)
    {
        _left = left;
        _right = right;
    }

    public bool Interpret(IReadOnlyDictionary<string, bool> context)
        => _left.Interpret(context) || _right.Interpret(context);
}
