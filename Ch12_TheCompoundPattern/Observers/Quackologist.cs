using Ch12_TheCompoundPattern.Interfaces;

namespace Ch12_TheCompoundPattern.Observers;

public sealed class Quackologist : IObserver
{
    public void Update(IQuackObservable duck)
    {
        if (duck is IQuackable quackable)
        {
            Console.WriteLine($"Quackologist: heard {quackable.Name}.");
        }
    }
}