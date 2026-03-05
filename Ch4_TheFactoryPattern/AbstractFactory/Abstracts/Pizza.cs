namespace Ch4_TheFactoryPattern.AbstractFactory.Abstracts;

using Ch4_TheFactoryPattern.AbstractFactory.Ingredients.Interfaces;

public abstract class Pizza
{
    public string Name { get; set; } = string.Empty;
    protected IDough? Dough { get; set; }
    protected ISauce? Sauce { get; set; }
    protected ICheese? Cheese { get; set; }
    protected IVeggies[]? Veggies { get; set; }
    protected IPepperoni? Pepperoni { get; set; }
    protected IClams? Clam { get; set; }

    public abstract void Prepare();

    public virtual void Bake() 
        => Console.WriteLine("Bake for 25 minutes at 350°");

    public virtual void Cut()  
        => Console.WriteLine("Cutting the pizza into diagonal slices");

    public virtual void Box()  
        => Console.WriteLine("Place pizza in official PizzaStore box");

    public override string ToString()
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine($"---- {Name} ----");
        if (Dough is not null) sb.AppendLine($"Dough: {Dough}");
        if (Sauce is not null) sb.AppendLine($"Sauce: {Sauce}");
        if (Cheese is not null) sb.AppendLine($"Cheese: {Cheese}");
        if (Veggies is { Length: > 0 })
            sb.AppendLine($"Veggies: {string.Join(", ", (object[])Veggies)}");
        if (Pepperoni is not null) sb.AppendLine($"Pepperoni: {Pepperoni}");
        if (Clam is not null) sb.AppendLine($"Clam: {Clam}");
        return sb.ToString().TrimEnd();
    }
}
