namespace Ch04_TheFactoryPattern.FactoryMethod.Stores;

using Ch04_TheFactoryPattern.FactoryMethod.Abstracts;
using Ch04_TheFactoryPattern.FactoryMethod.ChicagoStyle;

public class ChicagoPizzaStore : PizzaStore
{
    protected override Pizza CreatePizza(string type)
    {
        return type.ToLower() switch
        {
            "cheese" => new ChicagoStyleCheesePizza(),
            "pepperoni" => new ChicagoStylePepperoniPizza(),
            "clam" => new ChicagoStyleClamPizza(),
            "veggie" => new ChicagoStyleVeggiePizza(),
            _ => throw new ArgumentException($"Unknown pizza type: {type}")
        };
    }
}

