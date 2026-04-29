namespace Ch04_TheFactoryPattern.SimpleFactory.Models;

public class CheesePizza : Pizza
{
    public CheesePizza()
    {
        Name = "Cheese Pizza";
        Dough = "Regular Crust";
        Sauce = "Marinara Pizza Sauce";
        Toppings.Add("Fresh Mozzarella");
        Toppings.Add("Parmesan");
    }
}

