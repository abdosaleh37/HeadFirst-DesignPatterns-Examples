namespace Ch04_TheFactoryPattern.AbstractFactory.Ingredients.Chicago;

using Ch04_TheFactoryPattern.AbstractFactory.Ingredients.Interfaces;

public class ThickCrustDough : IDough
{
    public override string ToString() => "ThickCrust style extra thick crust dough";
}

