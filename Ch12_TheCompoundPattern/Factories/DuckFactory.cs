using Ch12_TheCompoundPattern.Interfaces;
using Ch12_TheCompoundPattern.Models;

namespace Ch12_TheCompoundPattern.Factories;

public sealed class DuckFactory : IAbstractDuckFactory
{
    public IQuackable CreateMallardDuck() => new MallardDuck();

    public IQuackable CreateRedheadDuck() => new RedheadDuck();

    public IQuackable CreateDuckCall() => new DuckCall();

    public IQuackable CreateRubberDuck() => new RubberDuck();
}