using Ch12_TheCompoundPattern.Interfaces;

namespace Ch12_TheCompoundPattern.Models;

public abstract class QuackableBase : IQuackable
{
    private readonly Observable _observable;

    protected QuackableBase()
    {
        _observable = new Observable(this);
    }

    public abstract string Name { get; }

    public abstract void Quack();

    public virtual void RegisterObserver(IObserver observer)
    {
        _observable.RegisterObserver(observer);
    }

    public virtual void NotifyObservers()
    {
        _observable.NotifyObservers();
    }
}