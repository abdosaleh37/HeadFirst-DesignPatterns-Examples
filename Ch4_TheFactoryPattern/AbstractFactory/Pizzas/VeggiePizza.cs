namespace Ch4_TheFactoryPattern.AbstractFactory.Pizzas;

using Ch4_TheFactoryPattern.AbstractFactory.Abstracts;
using Ch4_TheFactoryPattern.AbstractFactory.Ingredients.Interfaces;

public class VeggiePizza : Pizza
{
    private readonly IPizzaIngredientFactory _ingredientFactory;

    public VeggiePizza(IPizzaIngredientFactory ingredientFactory)
        => _ingredientFactory = ingredientFactory;

    public override void Prepare()
    {
        Console.WriteLine($"  Preparing {Name}");
        Dough = _ingredientFactory.CreateDough();
        Sauce = _ingredientFactory.CreateSauce();
        Cheese = _ingredientFactory.CreateCheese();
        Veggies = _ingredientFactory.CreateVeggies();
        Console.WriteLine($"Dough: {Dough}");
        Console.WriteLine($"Sauce: {Sauce}");
        Console.WriteLine($"Cheese: {Cheese}");
        Console.WriteLine($"Veggies: {string.Join(", ", (object[])Veggies)}");
    }
}
