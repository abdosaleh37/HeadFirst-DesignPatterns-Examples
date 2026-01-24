using Ch1_Intro_DuckBehaviors.Behaviors.FlyBehaviors;
using Ch1_Intro_DuckBehaviors.Behaviors.QuackBehaviors;

namespace Ch1_Intro_DuckBehaviors.Models
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
