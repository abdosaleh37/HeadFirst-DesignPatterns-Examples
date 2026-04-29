using Ch03_TheDecoratorPattern.Abstracts;

namespace Ch03_TheDecoratorPattern.Condiments
{
    public class SteamedMilk : CondimentDecorator
    {
        public SteamedMilk(Beverage beverage)
        {
            Beverage = beverage;
            Description = beverage.Description + ", Steamed Milk";
        }

        public override double Cost() => 0.10 + Beverage.Cost();
    }
}

