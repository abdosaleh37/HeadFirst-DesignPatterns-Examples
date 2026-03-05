namespace Ch4_TheFactoryPattern.AbstractFactory.Ingredients.Chicago;

using Ch4_TheFactoryPattern.AbstractFactory.Ingredients.Interfaces;

public class ThickCrustDough : IDough
{
    public override string ToString() => "ThickCrust style extra thick crust dough";
}
