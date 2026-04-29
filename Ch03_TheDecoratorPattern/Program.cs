using Ch03_TheDecoratorPattern.Abstracts;
using Ch03_TheDecoratorPattern.Beverages;
using Ch03_TheDecoratorPattern.Condiments;

namespace Ch03_TheDecoratorPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("─── Chapter 3 · Decorator Pattern ──────────────────────────────");

            Console.WriteLine("Simple beverage");
            Beverage beverage1 = new Espresso();
            Console.WriteLine($"Order: {beverage1.Description}");
            Console.WriteLine($"Cost breakdown: 1.99 = {beverage1.Cost():0.00}");

            Console.WriteLine();
            Console.WriteLine("Single condiment");
            Beverage beverage2 = new DarkRoast();
            beverage2 = new Mocha(beverage2);
            Console.WriteLine($"Order: {beverage2.Description}");
            Console.WriteLine($"Cost breakdown: 0.99 + 0.20 = {beverage2.Cost():0.00}");

            Console.WriteLine();
            Console.WriteLine("Stacked condiments");

            Beverage beverage3 = new HouseBlend();
            beverage3 = new Soy(beverage3);
            beverage3 = new Mocha(beverage3);
            beverage3 = new Whip(beverage3);
            Console.WriteLine($"Order: {beverage3.Description}");
            Console.WriteLine($"Cost breakdown: 0.89 + 0.15 + 0.20 + 0.10 = {beverage3.Cost():0.00}");
        }
    }
}

