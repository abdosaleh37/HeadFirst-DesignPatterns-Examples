namespace Ch4_TheFactoryPattern.AbstractFactory.Stores;

using Ch4_TheFactoryPattern.AbstractFactory.Abstracts;
using Ch4_TheFactoryPattern.AbstractFactory.Factories;
using Ch4_TheFactoryPattern.AbstractFactory.Pizzas;

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
