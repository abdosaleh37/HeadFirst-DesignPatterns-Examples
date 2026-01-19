using CH0_Intro_DuckBehaviors.Behaviors.FlyBehaviors;
using CH0_Intro_DuckBehaviors.Behaviors.QuackBehaviors;

namespace CH0_Intro_DuckBehaviors.Models
{
    public class MallardDuck : Duck
    {
        public MallardDuck()
        {
            FlyBehavior = new FlyWithWings();
            QuackBehavior = new QuackSound();
        }

        public override void Display()
        {
            Console.WriteLine("I'm a real Mallard duck");
        }
    }
}
