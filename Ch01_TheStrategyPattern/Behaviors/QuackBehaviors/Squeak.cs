using Ch01_TheStrategyPattern.Interfaces;

namespace Ch01_TheStrategyPattern.Behaviors.QuackBehaviors
{
    public class Squeak : IQuackBehavior
    {
        public void Quack() => Console.WriteLine("Squeak squeak!");
    }
}

