namespace Ch4_TheFactoryPattern.FactoryMethod.ChicagoStyle;

using Ch4_TheFactoryPattern.FactoryMethod.Abstracts;

public class ChicagoStyleCheesePizza : Pizza
{
    public ChicagoStyleCheesePizza()
    {
        Name  = "Chicago Style Deep Dish Cheese Pizza";
        Dough = "Extra Thick Crust Dough";
        Sauce = "Plum Tomato Sauce";
        Toppings.Add("Shredded Mozzarella Cheese");
    }

    public override void Cut() 
        => Console.WriteLine("Cutting the pizza into square slices");
}
