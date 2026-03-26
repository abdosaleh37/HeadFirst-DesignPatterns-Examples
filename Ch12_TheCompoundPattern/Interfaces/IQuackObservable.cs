namespace Ch12_TheCompoundPattern.Interfaces;

public interface IQuackObservable
{
    void RegisterObserver(IObserver observer);
    void NotifyObservers();
}