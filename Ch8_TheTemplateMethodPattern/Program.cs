using Ch8_TheTemplateMethodPattern.Beverages;
using Ch8_TheTemplateMethodPattern.Frames;
using Ch8_TheTemplateMethodPattern.Sorting;

// ─────────────────────────────────────────────────────────────────────────────
//  CHAPTER 8 – THE TEMPLATE METHOD PATTERN
// ─────────────────────────────────────────────────────────────────────────────
PrintHeader("CHAPTER 8 – THE TEMPLATE METHOD PATTERN", '=');
Console.WriteLine(
    """
    The Template Method Pattern defines the skeleton of an algorithm in a method,
    deferring some steps to subclasses.  Template Method lets subclasses redefine
    certain steps of an algorithm without changing the algorithm's structure.

    Design Principle: The Hollywood Principle — "Don't call us, we'll call you."
    High-level components call low-level components, NOT the other way around.
    """);

// ─────────────────────────────────────────────────────────────────────────────
//  PART 1 – Classic Example: Tea and Coffee
// ─────────────────────────────────────────────────────────────────────────────
PrintHeader("PART 1: Tea and Coffee — The Classic Example", '-');
Console.WriteLine(
    """
    Both Tea and Coffee follow the same recipe skeleton:
        1. Boil water
        2. Brew        ← differs per beverage
        3. Pour in cup
        4. Add condiments ← differs per beverage

    CaffeineBeverage.PrepareRecipe() is the TEMPLATE METHOD — it defines the
    invariant skeleton.  Tea and Coffee override only Brew() and AddCondiments().
    """);

Console.WriteLine("\nMaking tea...");
var tea = new Tea();
tea.PrepareRecipe();

Console.WriteLine("\nMaking coffee...");
var coffee = new Coffee();
coffee.PrepareRecipe();

// ─────────────────────────────────────────────────────────────────────────────
//  PART 2 – Hooks: Letting Subclasses Influence the Algorithm
// ─────────────────────────────────────────────────────────────────────────────
PrintHeader("PART 2: Hooks — Subclasses Influence the Algorithm", '-');
Console.WriteLine(
    """
    A HOOK is a method declared in the abstract class with a default (often empty)
    implementation.  Subclasses CAN override hooks to hook into the algorithm at
    various points — but they don't HAVE to.

    Here, CustomerWantsCondiments() is a hook.  The default returns true (condiments
    always added).  TeaWithHook and CoffeeWithHook override it to ask the user.
    """);

Console.WriteLine("\nMaking tea with hook (will ask about condiments)...");
var teaHook = new TeaWithHook();
teaHook.PrepareRecipe();

Console.WriteLine("\nMaking coffee with hook (will ask about condiments)...");
var coffeeHook = new CoffeeWithHook();
coffeeHook.PrepareRecipe();

// ─────────────────────────────────────────────────────────────────────────────
//  PART 3 – Template Method in the .NET Framework: Array.Sort
// ─────────────────────────────────────────────────────────────────────────────
PrintHeader("PART 3: Template Method in the Wild — Array.Sort + IComparable<T>", '-');
Console.WriteLine(
    """
    The .NET Array.Sort() method is itself a template method!  The sorting algorithm
    is fixed, but it calls CompareTo() at each comparison step — and WE provide that
    step by implementing IComparable<T>.

    This is exactly the Template Method Pattern:
      • Array.Sort()   = template method (skeleton of the sort algorithm)
      • CompareTo()    = the step we fill in (like Brew() or AddCondiments())

    Here we sort Duck objects by weight.
    """);

Duck[] ducks =
[
    new Duck("Daffy",  8),
    new Duck("Dewey",  2),
    new Duck("Howard", 7),
    new Duck("Louie",  2),
    new Duck("Donald", 10),
    new Duck("Huey",   2),
];

Console.WriteLine("\nBefore sorting:");
foreach (var d in ducks) Console.WriteLine(d);

Array.Sort(ducks);   // Uses Duck.CompareTo() — our "step" in the sort template

Console.WriteLine("\nAfter sorting (ascending weight):");
foreach (var d in ducks) Console.WriteLine(d);

// ─────────────────────────────────────────────────────────────────────────────
//  PART 4 – Hollywood Principle: The Application Frame
// ─────────────────────────────────────────────────────────────────────────────
PrintHeader("PART 4: Hollywood Principle — Abstract Application Frame", '-');
Console.WriteLine(
    """
    The Hollywood Principle says: "Don't call us, we'll call you."

    AbstractApplicationFrame.Run() is the template method (owned by the framework).
    It calls Initialize(), Handle(), IsDone(), and Cleanup() — methods we override
    in concrete subclasses.  We NEVER call Run() ourselves from the subclass —
    the framework calls US!

    This decouples high-level (framework) from low-level (application) code.
    """);

Console.WriteLine("\nRunning CountdownApp via the abstract frame:");
var app = new CountdownApp();
app.Run();

// ─────────────────────────────────────────────────────────────────────────────
//  Summary
// ─────────────────────────────────────────────────────────────────────────────
Console.WriteLine();
PrintHeader("SUMMARY", '=');
Console.WriteLine(
    """
    ┌────────────────────────────────────────────────────────────────────────────┐
    │                    Template Method Pattern — Key Points                    │
    ├────────────────────────────────────────────────────────────────────────────┤
    │  • Defines the SKELETON of an algorithm in one method (the template)       │
    │  • Defers some steps to subclasses (abstract primitive operations)         │
    │  • Template method is sealed — subclasses cannot change the structure      │
    │  • HOOKS are optional override points with sensible defaults               │
    │  • Follows the Hollywood Principle — high-level calls low-level, not vice  │
    │    versa                                                                   │
    │  • Found everywhere in frameworks: Array.Sort, ASP.NET middleware, etc.    │
    │  • Promotes code reuse — invariant parts live once in the base class       │
    └────────────────────────────────────────────────────────────────────────────┘
    """);

// ─────────────────────────────────────────────────────────────────────────────
//  Helper
// ─────────────────────────────────────────────────────────────────────────────
static void PrintHeader(string title, char separator)
{
    string line = new string(separator, 79);
    Console.WriteLine();
    Console.WriteLine(line);
    Console.WriteLine($"  {title}");
    Console.WriteLine(line);
}
