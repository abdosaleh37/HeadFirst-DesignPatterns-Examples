using Ch01_TheStrategyPattern.Interfaces;

namespace Ch01_TheStrategyPattern.Behaviors.QuackBehaviors
{
    public class QuackSound : IQuackBehavior
    {
        public void Quack() => Console.WriteLine("Quack quack!");
    }
}

