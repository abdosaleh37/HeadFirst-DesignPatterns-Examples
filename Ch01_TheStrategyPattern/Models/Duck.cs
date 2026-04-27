using Ch01_TheStrategyPattern.Interfaces;

namespace Ch01_TheStrategyPattern.Models
{
    public abstract class Duck
    {
        public Duck() { }

        public IFlyBehavior FlyBehavior { get; set; } = null!;

        public IQuackBehavior QuackBehavior { get; set; } = null!;

        public void PerformFly() => FlyBehavior.Fly();

        public void PerformQuack() => QuackBehavior.Quack();

        public virtual void Swim() => Console.WriteLine("All ducks float, even decoys!");

        public abstract void Display();
    }
}

