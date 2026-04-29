using Ch03_TheDecoratorPattern.Abstracts;

namespace Ch03_TheDecoratorPattern.Beverages
{
    public class DarkRoast : Beverage
    {
        public DarkRoast() => Description = "Dark Roast Coffee";

        public override double Cost() => 0.99;
    }
}

