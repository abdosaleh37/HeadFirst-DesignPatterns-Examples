using Ch01_TheStrategyPattern.Behaviors.FlyBehaviors;
using Ch01_TheStrategyPattern.Behaviors.QuackBehaviors;

namespace Ch01_TheStrategyPattern.Models
{
    public class ModelDuck : Duck
    {
        public ModelDuck()
        {
            FlyBehavior = new FlyNoWay();
            QuackBehavior = new MuteQuack();
        }

        public override void Display() => Console.WriteLine("I'm a model duck");
    }
}

