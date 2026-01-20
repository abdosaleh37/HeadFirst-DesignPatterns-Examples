using Ch1_Intro_DuckBehaviors.Behaviors.FlyBehaviors;
using Ch1_Intro_DuckBehaviors.Behaviors.QuackBehaviors;

namespace Ch1_Intro_DuckBehaviors.Models
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
