namespace Ch14_Appendix.Interpreter;

public sealed class VariableExpression : IExpression
{
    private readonly string _name;

    public VariableExpression(string name)
    {
        _name = name;
    }

    public bool Interpret(IReadOnlyDictionary<string, bool> context) => context[_name];
}
