namespace Ch12_TheCompoundPattern.Interfaces;

public interface IObserver
{
    void Update(IQuackObservable duck);
}