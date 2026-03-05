using Ch3_TheDecoratorPattern.Abstracts;

namespace Ch3_TheDecoratorPattern.Condiments
{
    public class Soy : CondimentDecorator
    {
        public Soy(Beverage beverage)
        {
            Beverage = beverage;
            Description = beverage.Description + ", Soy";
        }

        public override double Cost() => 0.15 + Beverage.Cost();
    }
}
