using Ch1_Intro_DuckBehaviors.Behaviors.FlyBehaviors;
using Ch1_Intro_DuckBehaviors.Models;

namespace Ch1_Intro_DuckBehaviors
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
