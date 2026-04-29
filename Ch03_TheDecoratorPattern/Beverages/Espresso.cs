using Ch03_TheDecoratorPattern.Abstracts;

namespace Ch03_TheDecoratorPattern.Beverages
{
    public class Espresso : Beverage
    {
        public Espresso() => Description = "Espresso Coffee";

        public override double Cost() => 1.99;
    }
}

