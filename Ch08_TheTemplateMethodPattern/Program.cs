using Ch08_TheTemplateMethodPattern.Beverages;
using Ch08_TheTemplateMethodPattern.Frames;
using Ch08_TheTemplateMethodPattern.Sorting;

PrintSection("Chapter 8 - Template Method Pattern");

PrintSection("1) Beverage template and hooks");
Console.WriteLine("Tea:");
new Tea().PrepareRecipe();

Console.WriteLine("\nCoffee:");
new Coffee().PrepareRecipe();

Console.WriteLine("\nTea with hook (prompts for condiments):");
new TeaWithHook().PrepareRecipe();

Console.WriteLine("\nCoffee with hook (prompts for condiments):");
new CoffeeWithHook().PrepareRecipe();

PrintSection("2) Sorting with IComparable");
Duck[] ducks =
[
    new Duck("Daffy", 8),
    new Duck("Dewey", 2),
    new Duck("Howard", 7),
    new Duck("Louie", 2),
    new Duck("Donald", 10),
    new Duck("Huey", 2),
];

Console.WriteLine("Before sorting:");
foreach (var duck in ducks)
{
    Console.WriteLine(duck);
}

Array.Sort(ducks);

Console.WriteLine("After sorting:");
foreach (var duck in ducks)
{
    Console.WriteLine(duck);
}

PrintSection("3) Hollywood principle frame");
var app = new CountdownApp();
app.Run();

static void PrintSection(string title)
{
    Console.WriteLine();
    Console.WriteLine(new string('-', 60));
    Console.WriteLine(title);
    Console.WriteLine(new string('-', 60));
}
