namespace Ch12_TheCompoundPattern.Interfaces;

public interface IAbstractDuckFactory
{
    IQuackable CreateMallardDuck();
    IQuackable CreateRedheadDuck();
    IQuackable CreateDuckCall();
    IQuackable CreateRubberDuck();
}