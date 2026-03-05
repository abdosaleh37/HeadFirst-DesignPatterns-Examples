namespace Ch4_TheFactoryPattern.SimpleFactory.Factories;

using Ch4_TheFactoryPattern.SimpleFactory.Models;

public class SimplePizzaFactory
{
    public Pizza? CreatePizza(string type)
    {
        return type.ToLower() switch
        {
            "cheese" => new CheesePizza(),
            "greek" => new GreekPizza(),
            "pepperoni" => new PepperoniPizza(),
            _ => null
        };
    }
}
