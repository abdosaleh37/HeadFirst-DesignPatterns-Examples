namespace Ch04_TheFactoryPattern.FactoryMethod.ChicagoStyle;

using Ch04_TheFactoryPattern.FactoryMethod.Abstracts;

public class ChicagoStylePepperoniPizza : Pizza
{
    public ChicagoStylePepperoniPizza()
    {
        Name = "Chicago Style Deep Dish Pepperoni Pizza";
        Dough = "Extra Thick Crust Dough";
        Sauce = "Plum Tomato Sauce";
        Toppings.Add("Shredded Mozzarella Cheese");
        Toppings.Add("Black Olives");
        Toppings.Add("Spinach");
        Toppings.Add("Eggplant");
        Toppings.Add("Sliced Pepperoni");
    }

    public override void Cut() 
        => Console.WriteLine("Cutting the pizza into square slices");
}

