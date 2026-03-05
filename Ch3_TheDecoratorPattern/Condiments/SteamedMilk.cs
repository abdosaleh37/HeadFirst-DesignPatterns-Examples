using Ch3_TheDecoratorPattern.Abstracts;

namespace Ch3_TheDecoratorPattern.Condiments
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
