using Ch03_TheDecoratorPattern.Abstracts;

namespace Ch03_TheDecoratorPattern.Condiments
{
    public class Mocha : CondimentDecorator
    {
        public Mocha(Beverage beverage)
        {
            Beverage = beverage;
            Description = beverage.Description + ", Mocha";
        }

        public override double Cost() => 0.20 + Beverage.Cost();
    }
}

