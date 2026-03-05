namespace Ch4_TheFactoryPattern.SimpleFactory.Models;

public class GreekPizza : Pizza
{
    public GreekPizza()
    {
        Name = "Greek Pizza";
        Dough = "Thin Crust Dough";
        Sauce = "Tomato Sauce";
        Toppings.Add("Feta Cheese");
        Toppings.Add("Kalamata Olives");
        Toppings.Add("Sun-dried Tomatoes");
    }
}
