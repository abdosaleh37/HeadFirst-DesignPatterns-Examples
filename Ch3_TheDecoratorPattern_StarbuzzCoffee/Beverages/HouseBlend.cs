using Ch3_TheDecoratorPattern_StarbuzzCoffee.Abstracts;

namespace Ch3_TheDecoratorPattern_StarbuzzCoffee.Beverages
{
    public class HouseBlend : Beverage
    {
        public HouseBlend() => Description = "House Blend Coffee";

        public override double Cost() => 0.89;
    }
}
