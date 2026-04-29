namespace Ch04_TheFactoryPattern.AbstractFactory.Stores;

using Ch04_TheFactoryPattern.AbstractFactory.Abstracts;
using Ch04_TheFactoryPattern.AbstractFactory.Factories;
using Ch04_TheFactoryPattern.AbstractFactory.Pizzas;

public class NYPizzaStore : PizzaStore
{
    protected override Pizza CreatePizza(string type)
    {
        var ingredientFactory = new NYPizzaIngredientFactory();

        Pizza pizza = type.ToLower() switch
        {
            "cheese" => new CheesePizza(ingredientFactory) { Name = "NY Style Cheese Pizza" },
            "clam" => new ClamPizza(ingredientFactory) { Name = "NY Style Clam Pizza" },
            "pepperoni" => new PepperoniPizza(ingredientFactory) { Name = "NY Style Pepperoni Pizza" },
            "veggie" => new VeggiePizza(ingredientFactory) { Name = "NY Style Veggie Pizza" },
            _ => throw new ArgumentException($"Unknown pizza type: {type}")
        };

        return pizza;
    }
}

