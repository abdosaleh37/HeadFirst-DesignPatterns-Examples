using Ch01_TheStrategyPattern.Behaviors.FlyBehaviors;
using Ch01_TheStrategyPattern.Behaviors.QuackBehaviors;

namespace Ch01_TheStrategyPattern.Models
{
    public class MallardDuck : Duck
    {
        public MallardDuck()
        {
            FlyBehavior = new FlyWithWings();
            QuackBehavior = new QuackSound();
        }

        public override void Display() => Console.WriteLine("I'm a real Mallard duck");
    }
}

