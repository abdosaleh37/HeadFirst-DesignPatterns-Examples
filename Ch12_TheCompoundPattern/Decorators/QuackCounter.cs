using Ch12_TheCompoundPattern.Interfaces;
using System.Threading;

namespace Ch12_TheCompoundPattern.Decorators;

public sealed class QuackCounter : IQuackable
{
    private static int _numberOfQuacks;
    private readonly IQuackable _duck;

    public QuackCounter(IQuackable duck)
    {
        _duck = duck;
    }

    public static int NumberOfQuacks => _numberOfQuacks;

    public string Name => _duck.Name;

    public void Quack()
    {
        _duck.Quack();
        Interlocked.Increment(ref _numberOfQuacks);
    }

    public void RegisterObserver(IObserver observer)
    {
        _duck.RegisterObserver(observer);
    }

    public void NotifyObservers()
    {
        _duck.NotifyObservers();
    }

    public static void Reset()
    {
        Interlocked.Exchange(ref _numberOfQuacks, 0);
    }
}