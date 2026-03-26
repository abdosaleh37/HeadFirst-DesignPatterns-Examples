using Ch12_TheCompoundPattern.Interfaces;

namespace Ch12_TheCompoundPattern.Composites;

public sealed class Flock : IQuackable
{
    private readonly List<IQuackable> _quackers = new();

    public string Name => "Flock";

    public void Add(IQuackable quacker)
    {
        _quackers.Add(quacker);
    }

    public void Quack()
    {
        foreach (var quacker in _quackers)
        {
            quacker.Quack();
        }
    }

    public void RegisterObserver(IObserver observer)
    {
        foreach (var quacker in _quackers)
        {
            quacker.RegisterObserver(observer);
        }
    }

    public void NotifyObservers()
    {
        // Intentionally empty: concrete quackers notify observers themselves.
    }
}