using Ch3_TheDecoratorPattern_StarbuzzCoffee.Abstracts;

namespace Ch3_TheDecoratorPattern_StarbuzzCoffee.Beverages
{
    public class DarkRoast : Beverage
    {
        public DarkRoast() => Description = "Dark Roast Coffee";

        public override double Cost() => 0.99;
    }
}
