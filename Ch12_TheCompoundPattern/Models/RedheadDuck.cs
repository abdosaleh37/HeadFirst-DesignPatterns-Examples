namespace Ch12_TheCompoundPattern.Models;

public sealed class RedheadDuck : QuackableBase
{
    public override string Name => "Redhead Duck";

    public override void Quack()
    {
        Console.WriteLine("Redhead Duck: Quack");
        NotifyObservers();
    }
}