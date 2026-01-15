using Intro_DuckBehaviors.Behaviors.FlyBehaviors;
using Intro_DuckBehaviors.Behaviors.QuackBehaviors;

namespace Intro_DuckBehaviors.Models
{
    public class ModelDuck : Duck
    {
        public ModelDuck()
        {
            FlyBehavior = new FlyNoWay();
            QuackBehavior = new MuteQuack();
        }

        public override void Display()
        {
            Console.WriteLine("I'm a model duck");
        }
    }
}
