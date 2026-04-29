namespace Ch04_TheFactoryPattern.AbstractFactory.Factories;

using Ch04_TheFactoryPattern.AbstractFactory.Ingredients.Chicago;
using Ch04_TheFactoryPattern.AbstractFactory.Ingredients.Interfaces;
using Ch04_TheFactoryPattern.AbstractFactory.Ingredients.NY;

public class ChicagoPizzaIngredientFactory : IPizzaIngredientFactory
{
    public IDough CreateDough() 
        => new ThickCrustDough();

    public ISauce CreateSauce() 
        => new PlumTomatoSauce();

    public ICheese CreateCheese() 
        => new MozzarellaCheese();

    public IVeggies[] CreateVeggies() 
        => [new BlackOlives(), new Spinach(), new EggPlant()];

    public IPepperoni CreatePepperoni() 
        => new SlicedPepperoni();

    public IClams CreateClams() 
        => new FrozenClams();
}

