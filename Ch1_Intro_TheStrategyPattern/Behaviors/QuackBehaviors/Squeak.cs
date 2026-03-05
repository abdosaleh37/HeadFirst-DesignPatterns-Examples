using Ch1_Intro_TheStrategyPattern.Interfaces;

namespace Ch1_Intro_TheStrategyPattern.Behaviors.QuackBehaviors
{
    public class Squeak : IQuackBehavior
    {
        public void Quack() => Console.WriteLine("Squeak squeak!");
    }
}
