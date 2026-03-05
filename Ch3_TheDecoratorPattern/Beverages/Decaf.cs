using Ch3_TheDecoratorPattern.Abstracts;

namespace Ch3_TheDecoratorPattern.Beverages
{
    public class Decaf : Beverage
    {
        public Decaf() => Description = "Decaf Coffee";

        public override double Cost() => 1.05;
    }
}
