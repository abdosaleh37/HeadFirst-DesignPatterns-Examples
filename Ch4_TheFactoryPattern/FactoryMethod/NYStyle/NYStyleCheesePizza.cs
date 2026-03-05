namespace Ch4_TheFactoryPattern.FactoryMethod.NYStyle;

using Ch4_TheFactoryPattern.FactoryMethod.Abstracts;

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
