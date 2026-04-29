namespace Ch04_TheFactoryPattern.AbstractFactory.Factories;

using Ch04_TheFactoryPattern.AbstractFactory.Ingredients.Interfaces;
using Ch04_TheFactoryPattern.AbstractFactory.Ingredients.NY;

public class NYPizzaIngredientFactory : IPizzaIngredientFactory
{
    public IDough CreateDough() 
        => new ThinCrustDough();

    public ISauce CreateSauce() 
        => new MarinaraSauce();

    public ICheese CreateCheese() 
        => new ReggianoCheese();

    public IVeggies[] CreateVeggies() 
        => [new Garlic(), new Onion(), new Mushroom(), new RedPepper()];

    public IPepperoni CreatePepperoni() 
        => new SlicedPepperoni();

    public IClams CreateClams() 
        => new FreshClams();
}

