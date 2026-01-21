using Ch3_TheDecoratorPattern_StarbuzzCoffee.Abstracts;

namespace Ch3_TheDecoratorPattern_StarbuzzCoffee.Condiments
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
