namespace Ch04_TheFactoryPattern.SimpleFactory.Stores;

using Ch04_TheFactoryPattern.SimpleFactory.Factories;
using Ch04_TheFactoryPattern.SimpleFactory.Models;

public class SimplePizzaStore
{
    private readonly SimplePizzaFactory _factory;

    public SimplePizzaStore(SimplePizzaFactory factory)
        => _factory = factory;

    public Pizza? OrderPizza(string type)
    {
        Pizza? pizza = _factory.CreatePizza(type);

        if (pizza is null)
        {
            Console.WriteLine($"Sorry, we don't make a {type} pizza.");
            return null;
        }

        pizza.Prepare();
        pizza.Bake();
        pizza.Cut();
        pizza.Box();
        return pizza;
    }
}

