using Ch4_TheFactoryPattern.SimpleFactory.Factories;
using Ch4_TheFactoryPattern.SimpleFactory.Stores;

using FMStores  = Ch4_TheFactoryPattern.FactoryMethod.Stores;
using AFStores  = Ch4_TheFactoryPattern.AbstractFactory.Stores;

PrintHeader("CHAPTER 4 – THE FACTORY PATTERN", '=');

// ─────────────────────────────────────────────────────────────
//  PART 1 – Simple Factory
// ─────────────────────────────────────────────────────────────
PrintHeader("PART 1: Simple Factory", '-');
Console.WriteLine(
    """
    The Simple Factory is NOT a formal design pattern — it is a programming idiom
    that encapsulates object creation in a single class.  Easy to understand, but
    the factory class must be modified every time a new product type is added
    (violates the Open/Closed Principle).
    """);

var factory = new SimplePizzaFactory();
var simpleStore = new SimplePizzaStore(factory);

Console.WriteLine("\n[Simple Store] Ordering a Cheese Pizza:");
simpleStore.OrderPizza("cheese");

Console.WriteLine("\n[Simple Store] Ordering a Pepperoni Pizza:");
simpleStore.OrderPizza("pepperoni");

Console.WriteLine("\n[Simple Store] Ordering an unknown type:");
simpleStore.OrderPizza("pineapple");

// ─────────────────────────────────────────────────────────────
//  PART 2 – Factory Method
// ─────────────────────────────────────────────────────────────
PrintHeader("PART 2: Factory Method Pattern", '-');
Console.WriteLine(
    """
    The Factory Method Pattern defines an interface for creating an object but lets
    subclasses decide which class to instantiate.  The abstract PizzaStore declares
    CreatePizza() (the factory method); NY and Chicago stores override it.
    The OrderPizza() template method in the base class is never changed — it always
    calls CreatePizza() without knowing the concrete type.

    Design Principle: "Depend upon abstractions; do not depend upon concrete classes."
    (Dependency Inversion Principle)
    """);

var nyStore      = new FMStores.NYPizzaStore();
var chicagoStore = new FMStores.ChicagoPizzaStore();

Console.WriteLine("\n[NY Store – Factory Method] Ethan orders a Cheese Pizza:");
var pizza1 = nyStore.OrderPizza("cheese");
Console.WriteLine($"  => {pizza1.Name}\n");

Console.WriteLine("[NY Store – Factory Method] Joel orders a Clam Pizza:");
var pizza2 = nyStore.OrderPizza("clam");
Console.WriteLine($"  => {pizza2.Name}\n");

Console.WriteLine("[Chicago Store – Factory Method] Ethan orders a Cheese Pizza:");
var pizza3 = chicagoStore.OrderPizza("cheese");
Console.WriteLine($"  => {pizza3.Name}\n");

Console.WriteLine("[Chicago Store – Factory Method] Joel orders a Pepperoni Pizza:");
var pizza4 = chicagoStore.OrderPizza("pepperoni");
Console.WriteLine($"  => {pizza4.Name}\n");

Console.WriteLine("[Chicago Store – Factory Method] Ordering all four types:");
foreach (var type in new[] { "cheese", "pepperoni", "clam", "veggie" })
{
    Console.WriteLine($"\n  >> {type.ToUpper()}:");
    chicagoStore.OrderPizza(type);
}

// ─────────────────────────────────────────────────────────────
//  PART 3 – Abstract Factory
// ─────────────────────────────────────────────────────────────
PrintHeader("PART 3: Abstract Factory Pattern", '-');
Console.WriteLine(
    """
    The Abstract Factory Pattern provides an interface for creating FAMILIES of
    related or dependent objects without specifying their concrete classes.

    Here, IPizzaIngredientFactory is the abstract factory.  NY and Chicago
    ingredient factories are concrete factories that produce a CONSISTENT FAMILY
    of ingredients (dough + sauce + cheese + veggies + pepperoni + clams).

    The pizza classes (CheesePizza, ClamPizza, …) are now location-independent —
    they work with any ingredient factory.  The store injects the correct factory,
    so the same four pizza classes serve every region.
    """);

var afNyStore      = new AFStores.NYPizzaStore();
var afChicagoStore = new AFStores.ChicagoPizzaStore();

Console.WriteLine("\n[NY Store – Abstract Factory] Ordering a Cheese Pizza:");
var af1 = afNyStore.OrderPizza("cheese");
Console.WriteLine();
Console.WriteLine(af1);

Console.WriteLine("\n[NY Store – Abstract Factory] Ordering a Clam Pizza:");
var af2 = afNyStore.OrderPizza("clam");
Console.WriteLine();
Console.WriteLine(af2);

Console.WriteLine("\n[Chicago Store – Abstract Factory] Ordering a Veggie Pizza:");
var af3 = afChicagoStore.OrderPizza("veggie");
Console.WriteLine();
Console.WriteLine(af3);

Console.WriteLine("\n[Chicago Store – Abstract Factory] Ordering a Pepperoni Pizza:");
var af4 = afChicagoStore.OrderPizza("pepperoni");
Console.WriteLine();
Console.WriteLine(af4);

Console.WriteLine("\n[Cross-region comparison – same CheesePizza class, different factories]");
Console.WriteLine("NY Cheese:");
Console.WriteLine(afNyStore.OrderPizza("cheese"));
Console.WriteLine("Chicago Cheese:");
Console.WriteLine(afChicagoStore.OrderPizza("cheese"));

PrintHeader("END OF DEMO", '=');

// ─── helpers ─────────────────────────────────────────────────
static void PrintHeader(string title, char border)
{
    var line = new string(border, 60);
    Console.WriteLine();
    Console.WriteLine(line);
    Console.WriteLine($"  {title}");
    Console.WriteLine(line);
}

