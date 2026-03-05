namespace Ch4_TheFactoryPattern.FactoryMethod.ChicagoStyle;

using Ch4_TheFactoryPattern.FactoryMethod.Abstracts;

public class ChicagoStyleClamPizza : Pizza
{
    public ChicagoStyleClamPizza()
    {
        Name  = "Chicago Style Deep Dish Clam Pizza";
        Dough = "Extra Thick Crust Dough";
        Sauce = "Plum Tomato Sauce";
        Toppings.Add("Shredded Mozzarella Cheese");
        Toppings.Add("Frozen Clams from Chesapeake Bay");
    }

    public override void Cut() 
        => Console.WriteLine("Cutting the pizza into square slices");
}
