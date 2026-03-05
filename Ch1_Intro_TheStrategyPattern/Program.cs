using Ch1_Intro_TheStrategyPattern.Behaviors.FlyBehaviors;
using Ch1_Intro_TheStrategyPattern.Models;

namespace Ch1_Intro_TheStrategyPattern
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
