using Intro_DuckBehaviors.Behaviors.FlyBehaviors;
using Intro_DuckBehaviors.Models;

namespace Intro_DuckBehaviors
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
