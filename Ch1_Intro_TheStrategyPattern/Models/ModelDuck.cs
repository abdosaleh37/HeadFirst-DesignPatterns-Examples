using Ch1_Intro_TheStrategyPattern.Behaviors.FlyBehaviors;
using Ch1_Intro_TheStrategyPattern.Behaviors.QuackBehaviors;

namespace Ch1_Intro_TheStrategyPattern.Models
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
