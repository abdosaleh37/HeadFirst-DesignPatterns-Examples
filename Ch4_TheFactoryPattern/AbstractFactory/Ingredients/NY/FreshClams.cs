namespace Ch4_TheFactoryPattern.AbstractFactory.Ingredients.NY;

using Ch4_TheFactoryPattern.AbstractFactory.Ingredients.Interfaces;

public class FreshClams : IClams
{
    public override string ToString() => "Fresh Clams from Long Island Sound";
}
