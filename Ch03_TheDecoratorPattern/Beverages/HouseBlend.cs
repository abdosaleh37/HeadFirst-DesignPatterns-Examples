using Ch03_TheDecoratorPattern.Abstracts;

namespace Ch03_TheDecoratorPattern.Beverages
{
    public class HouseBlend : Beverage
    {
        public HouseBlend() => Description = "House Blend Coffee";

        public override double Cost() => 0.89;
    }
}

