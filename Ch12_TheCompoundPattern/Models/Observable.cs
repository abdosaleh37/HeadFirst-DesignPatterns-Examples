using Ch12_TheCompoundPattern.Interfaces;

namespace Ch12_TheCompoundPattern.Models;

public sealed class Observable
{
    private readonly List<IObserver> _observers = new();
    private readonly IQuackObservable _duck;

    public Observable(IQuackObservable duck)
    {
        _duck = duck;
    }

    public void RegisterObserver(IObserver observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_duck);
        }
    }
}