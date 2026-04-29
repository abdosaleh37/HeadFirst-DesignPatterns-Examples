namespace Ch04_TheFactoryPattern.SimpleFactory.Models;

public class PepperoniPizza : Pizza
{
    public PepperoniPizza()
    {
        Name = "Pepperoni Pizza";
        Dough = "Regular Crust";
        Sauce = "Tomato Sauce";
        Toppings.Add("Sliced Pepperoni");
        Toppings.Add("Sliced Onion");
        Toppings.Add("Grated Parmesan Cheese");
    }
}

