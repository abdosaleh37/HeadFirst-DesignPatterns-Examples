using Ch3_TheDecoratorPattern.Abstracts;
using Ch3_TheDecoratorPattern.Beverages;
using Ch3_TheDecoratorPattern.Condiments;

namespace Ch3_TheDecoratorPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Beverage beverage1 = new Espresso();
            Console.WriteLine($"{beverage1.Description} $" +
                $"{beverage1.Cost():0.00}");

            Console.WriteLine("========================================================================");

            Beverage beverage2 = new DarkRoast();
            beverage2 = new Mocha(beverage2);
            beverage2 = new Mocha(beverage2);
            beverage2 = new Whip(beverage2);
            Console.WriteLine($"{beverage2.Description} $" +
                $"{beverage2.Cost():0.00}");

            Console.WriteLine("========================================================================");

            Beverage beverage3 = new HouseBlend();
            beverage3 = new Soy(beverage3);
            beverage3 = new Mocha(beverage3);
            beverage3 = new Whip(beverage3);
            Console.WriteLine($"{beverage3.Description} $" +
                $"{beverage3.Cost():0.00}");
        }
    }
}
