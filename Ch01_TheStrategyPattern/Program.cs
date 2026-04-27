using Ch01_TheStrategyPattern.Behaviors.FlyBehaviors;
using Ch01_TheStrategyPattern.Models;

namespace Ch01_TheStrategyPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("─── Chapter 1 · Strategy Pattern ───────────────────────────────");
            Console.WriteLine("Scenario A: MallardDuck uses composed behaviors");

            Duck mallard = new MallardDuck();
            Console.WriteLine("Mallard is configured with FlyWithWings + QuackSound in its constructor.");
            mallard.Display();
            mallard.PerformFly();
            mallard.PerformQuack();

            Console.WriteLine();
            Console.WriteLine("Scenario B: ModelDuck changes flying behavior at runtime (the magic!)");

            Duck model = new ModelDuck();
            Console.WriteLine("ModelDuck starts with FlyNoWay, so it cannot fly yet.");
            model.Display();
            model.PerformFly();

            Console.WriteLine("Swap in FlyRocketPowered to change behavior without changing the duck class.");
            model.FlyBehavior = new FlyRocketPowered();
            model.PerformFly();
        }
    }
}

