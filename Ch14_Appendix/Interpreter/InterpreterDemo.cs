namespace Ch14_Appendix.Interpreter;

public static class InterpreterDemo
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("--- Interpreter Pattern ---");

        var context = new Dictionary<string, bool>
        {
            ["A"] = true,
            ["B"] = false,
            ["C"] = true
        };

        IExpression expression = new AndExpression(
            new VariableExpression("A"),
            new OrExpression(
                new NotExpression(new VariableExpression("B")),
                new VariableExpression("C")));

        Console.WriteLine("Expression: A AND (NOT B OR C)");
        Console.WriteLine($"Result: {expression.Interpret(context)}");
    }
}
