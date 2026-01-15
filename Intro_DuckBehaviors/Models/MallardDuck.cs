using Intro_DuckBehaviors.Behaviors.FlyBehaviors;
using Intro_DuckBehaviors.Behaviors.QuackBehaviors;

namespace Intro_DuckBehaviors.Models
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
