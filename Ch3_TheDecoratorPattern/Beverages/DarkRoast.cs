using Ch3_TheDecoratorPattern.Abstracts;

namespace Ch3_TheDecoratorPattern.Beverages
{
    public class DarkRoast : Beverage
    {
        public DarkRoast() => Description = "Dark Roast Coffee";

        public override double Cost() => 0.99;
    }
}
