using Ch04_TheFactoryPattern.SimpleFactory.Factories;
using Ch04_TheFactoryPattern.SimpleFactory.Stores;

using FMStores = Ch04_TheFactoryPattern.FactoryMethod.Stores;
using AFStores = Ch04_TheFactoryPattern.AbstractFactory.Stores;

PrintHeader("CHAPTER 4 - THE FACTORY PATTERN", '=');

// -------------------------------------------------------------
//  PART 1 - Simple Factory
// -------------------------------------------------------------
PrintHeader("PART 1: Simple Factory", '-');
Console.WriteLine(
    """
    Simple Factory centralizes object creation in one place.
    It is easy to start with, but adding types requires editing the factory.
    """
);

var factory = new SimplePizzaFactory();
var simpleStore = new SimplePizzaStore(factory);

Console.WriteLine("\n[Simple Store] Ordering a Cheese Pizza:");
simpleStore.OrderPizza("cheese");

Console.WriteLine("\n[Simple Store] Ordering a Pepperoni Pizza:");
simpleStore.OrderPizza("pepperoni");

Console.WriteLine("\n[Simple Store] Ordering an unknown type:");
simpleStore.OrderPizza("pineapple");

// -------------------------------------------------------------
//  PART 2 - Factory Method
// -------------------------------------------------------------
PrintHeader("PART 2: Factory Method Pattern", '-');
Console.WriteLine(
    """
    Factory Method moves product selection to store subclasses.
    OrderPizza remains stable in the base class while CreatePizza varies by region.
    This keeps creation extensible and aligned with DIP/OCP.
    """
);

var nyStore = new FMStores.NYPizzaStore();
var chicagoStore = new FMStores.ChicagoPizzaStore();

Console.WriteLine("\n[NY Store - Factory Method] Ethan orders a Cheese Pizza:");
var pizza1 = nyStore.OrderPizza("cheese");
Console.WriteLine($"  => {pizza1.Name}\n");

Console.WriteLine("[NY Store - Factory Method] Joel orders a Clam Pizza:");
var pizza2 = nyStore.OrderPizza("clam");
Console.WriteLine($"  => {pizza2.Name}\n");

Console.WriteLine("[Chicago Store - Factory Method] Ethan orders a Cheese Pizza:");
var pizza3 = chicagoStore.OrderPizza("cheese");
Console.WriteLine($"  => {pizza3.Name}\n");

Console.WriteLine("[Chicago Store - Factory Method] Joel orders a Pepperoni Pizza:");
var pizza4 = chicagoStore.OrderPizza("pepperoni");
Console.WriteLine($"  => {pizza4.Name}\n");

Console.WriteLine("[Chicago Store - Factory Method] Ordering all four types:");
foreach (var type in new[] { "cheese", "pepperoni", "clam", "veggie" })
{
    Console.WriteLine($"\n  >> {type.ToUpper()}:");
    chicagoStore.OrderPizza(type);
}

// -------------------------------------------------------------
//  PART 3 - Abstract Factory
// -------------------------------------------------------------
PrintHeader("PART 3: Abstract Factory Pattern", '-');
Console.WriteLine(
    """
    Abstract Factory creates families of related ingredients.
    Stores inject region factories, while pizza classes remain location-independent.
    Swapping the factory swaps the whole ingredient family consistently.
    """
);

var afNyStore = new AFStores.NYPizzaStore();
var afChicagoStore = new AFStores.ChicagoPizzaStore();

Console.WriteLine("\n[NY Store - Abstract Factory] Ordering a Cheese Pizza:");
var af1 = afNyStore.OrderPizza("cheese");
Console.WriteLine();
Console.WriteLine(af1);

Console.WriteLine("\n[NY Store - Abstract Factory] Ordering a Clam Pizza:");
var af2 = afNyStore.OrderPizza("clam");
Console.WriteLine();
Console.WriteLine(af2);

Console.WriteLine("\n[Chicago Store - Abstract Factory] Ordering a Veggie Pizza:");
var af3 = afChicagoStore.OrderPizza("veggie");
Console.WriteLine();
Console.WriteLine(af3);

Console.WriteLine("\n[Chicago Store - Abstract Factory] Ordering a Pepperoni Pizza:");
var af4 = afChicagoStore.OrderPizza("pepperoni");
Console.WriteLine();
Console.WriteLine(af4);

PrintHeader("END OF DEMO", '=');

// --- helpers -------------------------------------------------
static void PrintHeader(string title, char border)
{
    var line = new string(border, 60);
    Console.WriteLine();
    Console.WriteLine(line);
    Console.WriteLine($"  {title}");
    Console.WriteLine(line);
}


