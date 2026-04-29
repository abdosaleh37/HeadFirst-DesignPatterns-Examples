namespace Ch04_TheFactoryPattern.AbstractFactory.Stores;

using Ch04_TheFactoryPattern.AbstractFactory.Abstracts;
using Ch04_TheFactoryPattern.AbstractFactory.Factories;
using Ch04_TheFactoryPattern.AbstractFactory.Pizzas;

public class ChicagoPizzaStore : PizzaStore
{
    protected override Pizza CreatePizza(string type)
    {
        var ingredientFactory = new ChicagoPizzaIngredientFactory();

        Pizza pizza = type.ToLower() switch
        {
            "cheese" => new CheesePizza(ingredientFactory) { Name = "Chicago Style Cheese Pizza" },
            "clam" => new ClamPizza(ingredientFactory) { Name = "Chicago Style Clam Pizza" },
            "pepperoni" => new PepperoniPizza(ingredientFactory) { Name = "Chicago Style Pepperoni Pizza" },
            "veggie" => new VeggiePizza(ingredientFactory) { Name = "Chicago Style Veggie Pizza" },
            _ => throw new ArgumentException($"Unknown pizza type: {type}")
        };

        return pizza;
    }
}

