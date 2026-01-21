using Ch3_TheDecoratorPattern_StarbuzzCoffee.Abstracts;

namespace Ch3_TheDecoratorPattern_StarbuzzCoffee.Condiments
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
