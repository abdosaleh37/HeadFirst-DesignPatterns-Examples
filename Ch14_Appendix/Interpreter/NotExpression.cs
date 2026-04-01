namespace Ch14_Appendix.Interpreter;

public sealed class NotExpression : IExpression
{
    private readonly IExpression _inner;

    public NotExpression(IExpression inner)
    {
        _inner = inner;
    }

    public bool Interpret(IReadOnlyDictionary<string, bool> context)
        => !_inner.Interpret(context);
}
