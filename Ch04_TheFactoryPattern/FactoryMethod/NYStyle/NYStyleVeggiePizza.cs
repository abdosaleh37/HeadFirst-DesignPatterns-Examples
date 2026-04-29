namespace Ch04_TheFactoryPattern.FactoryMethod.NYStyle;

using Ch04_TheFactoryPattern.FactoryMethod.Abstracts;

public class NYStyleVeggiePizza : Pizza
{
    public NYStyleVeggiePizza()
    {
        Name = "NY Style Veggie Pizza";
        Dough = "Thin Crust Dough";
        Sauce = "Marinara Sauce";
        Toppings.Add("Grated Reggiano");
        Toppings.Add("Garlic");
        Toppings.Add("Onion");
        Toppings.Add("Mushrooms");
        Toppings.Add("Red Pepper");
        Toppings.Add("Black Olives");
    }
}

