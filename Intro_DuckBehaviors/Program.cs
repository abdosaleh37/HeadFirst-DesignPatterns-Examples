using CH0_Intro_DuckBehaviors.Behaviors.FlyBehaviors;
using CH0_Intro_DuckBehaviors.Models;

namespace CH0_Intro_DuckBehaviors
{
    public class Program
    {
        static void Main(string[] args)
        {
            Duck mallard = new MallardDuck();

            mallard.Display();
            mallard.PerformFly();
            mallard.PerformQuack();

            Console.WriteLine("========================================================================");

            Duck model = new ModelDuck();
            model.Display();
            model.PerformFly();
            model.FlyBehavior = new FlyRocketPowered();
            model.PerformFly();
        }
    }
}
