using Ch03_TheDecoratorPattern.Abstracts;

namespace Ch03_TheDecoratorPattern.Condiments
{
    public class Whip : CondimentDecorator
    {
        public Whip(Beverage beverage)
        {
            Beverage = beverage;
            Description = beverage.Description + ", Whip";
        }

        public override double Cost() => 0.10 + Beverage.Cost();
    }
}

