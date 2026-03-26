using Ch12_TheCompoundPattern.Decorators;
using Ch12_TheCompoundPattern.Interfaces;
using Ch12_TheCompoundPattern.Models;

namespace Ch12_TheCompoundPattern.Factories;

public sealed class CountingDuckFactory : IAbstractDuckFactory
{
    public IQuackable CreateMallardDuck() => new QuackCounter(new MallardDuck());

    public IQuackable CreateRedheadDuck() => new QuackCounter(new RedheadDuck());

    public IQuackable CreateDuckCall() => new QuackCounter(new DuckCall());

    public IQuackable CreateRubberDuck() => new QuackCounter(new RubberDuck());
}