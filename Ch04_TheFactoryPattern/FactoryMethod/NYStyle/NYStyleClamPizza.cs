namespace Ch04_TheFactoryPattern.FactoryMethod.NYStyle;

using Ch04_TheFactoryPattern.FactoryMethod.Abstracts;

public class NYStyleClamPizza : Pizza
{
    public NYStyleClamPizza()
    {
        Name = "NY Style Clam Pizza";
        Dough = "Thin Crust Dough";
        Sauce = "Marinara Sauce";
        Toppings.Add("Grated Reggiano");
        Toppings.Add("Fresh Clams from Long Island Sound");
    }
}

