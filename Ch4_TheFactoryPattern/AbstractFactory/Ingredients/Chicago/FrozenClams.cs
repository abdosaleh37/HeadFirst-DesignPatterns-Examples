namespace Ch4_TheFactoryPattern.AbstractFactory.Ingredients.Chicago;

using Ch4_TheFactoryPattern.AbstractFactory.Ingredients.Interfaces;

public class FrozenClams : IClams
{
    public override string ToString() => "Frozen Clams from Chesapeake Bay";
}
