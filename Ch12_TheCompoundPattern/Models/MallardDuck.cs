namespace Ch12_TheCompoundPattern.Models;

public sealed class MallardDuck : QuackableBase
{
    public override string Name => "Mallard Duck";

    public override void Quack()
    {
        Console.WriteLine("Mallard Duck: Quack");
        NotifyObservers();
    }
}