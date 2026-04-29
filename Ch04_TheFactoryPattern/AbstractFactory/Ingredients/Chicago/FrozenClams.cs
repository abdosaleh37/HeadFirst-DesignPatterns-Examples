namespace Ch04_TheFactoryPattern.AbstractFactory.Ingredients.Chicago;

using Ch04_TheFactoryPattern.AbstractFactory.Ingredients.Interfaces;

public class FrozenClams : IClams
{
    public override string ToString() => "Frozen Clams from Chesapeake Bay";
}

