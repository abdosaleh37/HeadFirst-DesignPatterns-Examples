namespace Ch04_TheFactoryPattern.FactoryMethod.Stores;

using Ch04_TheFactoryPattern.FactoryMethod.Abstracts;
using Ch04_TheFactoryPattern.FactoryMethod.NYStyle;

public class NYPizzaStore : PizzaStore
{
    protected override Pizza CreatePizza(string type)
    {
        return type.ToLower() switch
        {
            "cheese" => new NYStyleCheesePizza(),
            "pepperoni" => new NYStylePepperoniPizza(),
            "clam" => new NYStyleClamPizza(),
            "veggie" => new NYStyleVeggiePizza(),
            _ => throw new ArgumentException($"Unknown pizza type: {type}")
        };
    }
}

