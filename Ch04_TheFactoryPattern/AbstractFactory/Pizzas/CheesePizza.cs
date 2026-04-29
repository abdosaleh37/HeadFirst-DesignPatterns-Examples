namespace Ch04_TheFactoryPattern.AbstractFactory.Pizzas;

using Ch04_TheFactoryPattern.AbstractFactory.Abstracts;
using Ch04_TheFactoryPattern.AbstractFactory.Ingredients.Interfaces;

public class CheesePizza : Pizza
{
    private readonly IPizzaIngredientFactory _ingredientFactory;

    public CheesePizza(IPizzaIngredientFactory ingredientFactory)
        => _ingredientFactory = ingredientFactory;

    public override void Prepare()
    {
        Console.WriteLine($"Preparing {Name}");
        Dough = _ingredientFactory.CreateDough();
        Sauce = _ingredientFactory.CreateSauce();
        Cheese = _ingredientFactory.CreateCheese();
        Console.WriteLine($"Dough: {Dough}");
        Console.WriteLine($"Sauce: {Sauce}");
        Console.WriteLine($"Cheese: {Cheese}");
    }
}

