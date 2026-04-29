namespace Ch04_TheFactoryPattern.AbstractFactory.Abstracts;

public abstract class PizzaStore
{
    protected abstract Pizza CreatePizza(string type);

    public Pizza OrderPizza(string type)
    {
        Pizza pizza = CreatePizza(type);

        Console.WriteLine($"  --- Making a {pizza.Name} ---");
        pizza.Prepare();
        pizza.Bake();
        pizza.Cut();
        pizza.Box();
        return pizza;
    }
}

