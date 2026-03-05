namespace Ch4_TheFactoryPattern.SimpleFactory.Models;

public abstract class Pizza
{
    public string Name { get; protected set; } = string.Empty;
    protected string Dough { get; set; } = string.Empty;
    protected string Sauce { get; set; } = string.Empty;
    protected List<string> Toppings { get; } = new();

    public void Prepare()
    {
        Console.WriteLine($"Preparing {Name}");
        Console.WriteLine($"Tossing dough: {Dough}");
        Console.WriteLine($"Adding sauce: {Sauce}");
        Console.WriteLine("Adding toppings:");
        foreach (var topping in Toppings)
            Console.WriteLine($"{topping}");
    }

    public void Bake() => Console.WriteLine("Baking for 25 minutes at 350°");
    public void Cut() => Console.WriteLine("Cutting the pizza into diagonal slices");
    public void Box() => Console.WriteLine("Placing pizza in official PizzaStore box");

    public override string ToString() => Name;
}
