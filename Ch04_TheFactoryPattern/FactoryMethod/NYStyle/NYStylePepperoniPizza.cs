namespace Ch04_TheFactoryPattern.FactoryMethod.NYStyle;

using Ch04_TheFactoryPattern.FactoryMethod.Abstracts;

public class NYStylePepperoniPizza : Pizza
{
    public NYStylePepperoniPizza()
    {
        Name = "NY Style Pepperoni Pizza";
        Dough = "Thin Crust Dough";
        Sauce = "Marinara Sauce";
        Toppings.Add("Grated Reggiano");
        Toppings.Add("Sliced Pepperoni");
        Toppings.Add("Garlic");
        Toppings.Add("Onion");
        Toppings.Add("Mushrooms");
        Toppings.Add("Red Pepper");
    }
}

