using Ch3_TheDecoratorPattern.Abstracts;

namespace Ch3_TheDecoratorPattern.Beverages
{
    public class Espresso : Beverage
    {
        public Espresso() => Description = "Espresso Coffee";

        public override double Cost() => 1.99;
    }
}
