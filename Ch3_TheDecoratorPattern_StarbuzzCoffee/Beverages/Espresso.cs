using Ch3_TheDecoratorPattern_StarbuzzCoffee.Abstracts;

namespace Ch3_TheDecoratorPattern_StarbuzzCoffee.Beverages
{
    public class Espresso : Beverage
    {
        public Espresso() => Description = "Espresso Coffee";

        public override double Cost() => 1.99;
    }
}
