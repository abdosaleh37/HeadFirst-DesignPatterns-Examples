namespace Ch12_TheCompoundPattern.Interfaces;

public interface IQuackable : IQuackObservable
{
    string Name { get; }
    void Quack();
}