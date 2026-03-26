namespace Ch12_TheCompoundPattern.Models;

public sealed class RubberDuck : QuackableBase
{
    public override string Name => "Rubber Duck";

    public override void Quack()
    {
        Console.WriteLine("Rubber Duck: Squeak");
        NotifyObservers();
    }
}