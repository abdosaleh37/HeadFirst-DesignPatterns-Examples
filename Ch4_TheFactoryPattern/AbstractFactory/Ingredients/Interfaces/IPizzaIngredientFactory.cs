namespace Ch4_TheFactoryPattern.AbstractFactory.Ingredients.Interfaces;

public interface IPizzaIngredientFactory
{
    IDough CreateDough();
    ISauce CreateSauce();
    ICheese CreateCheese();
    IVeggies[] CreateVeggies();
    IPepperoni CreatePepperoni();
    IClams CreateClams();
}
