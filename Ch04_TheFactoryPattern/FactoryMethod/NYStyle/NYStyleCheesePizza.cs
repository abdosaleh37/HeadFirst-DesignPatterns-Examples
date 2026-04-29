namespace Ch04_TheFactoryPattern.FactoryMethod.NYStyle;

using Ch04_TheFactoryPattern.FactoryMethod.Abstracts;

public class NYStyleCheesePizza : Pizza
{
    public NYStyleCheesePizza()
    {
        Name = "NY Style Sauce and Cheese Pizza";
        Dough = "Thin Crust Dough";
        Sauce = "Marinara Sauce";
        Toppings.Add("Grated Reggiano");
    }
}

