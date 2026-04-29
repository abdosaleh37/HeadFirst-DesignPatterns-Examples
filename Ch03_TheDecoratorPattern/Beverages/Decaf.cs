using Ch03_TheDecoratorPattern.Abstracts;

namespace Ch03_TheDecoratorPattern.Beverages
{
    public class Decaf : Beverage
    {
        public Decaf() => Description = "Decaf Coffee";

        public override double Cost() => 1.05;
    }
}

