using Ch3_TheDecoratorPattern_StarbuzzCoffee.Abstracts;

namespace Ch3_TheDecoratorPattern_StarbuzzCoffee.Beverages
{
    public class Decaf : Beverage
    {
        public Decaf() => Description = "Decaf Coffee";

        public override double Cost() => 1.05;
    }
}
