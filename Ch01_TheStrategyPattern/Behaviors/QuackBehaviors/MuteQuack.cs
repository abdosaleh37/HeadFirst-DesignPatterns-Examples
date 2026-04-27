using Ch01_TheStrategyPattern.Interfaces;

namespace Ch01_TheStrategyPattern.Behaviors.QuackBehaviors
{
    public class MuteQuack : IQuackBehavior
    {
        public void Quack() => Console.WriteLine("<< Silence >>");
    }
}

