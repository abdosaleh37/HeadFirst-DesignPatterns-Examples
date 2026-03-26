namespace Ch12_TheCompoundPattern.Models;

public sealed class DuckCall : QuackableBase
{
    public override string Name => "Duck Call";

    public override void Quack()
    {
        Console.WriteLine("Duck Call: Kwak");
        NotifyObservers();
    }
}