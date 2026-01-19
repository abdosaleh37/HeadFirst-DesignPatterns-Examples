using CH0_Intro_DuckBehaviors.Behaviors.FlyBehaviors;
using CH0_Intro_DuckBehaviors.Behaviors.QuackBehaviors;

namespace CH0_Intro_DuckBehaviors.Models
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
