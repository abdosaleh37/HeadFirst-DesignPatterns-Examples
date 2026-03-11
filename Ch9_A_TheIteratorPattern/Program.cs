using Ch9_A_TheIteratorPattern.Client;
using Ch9_A_TheIteratorPattern.Menus;

// ─────────────────────────────────────────────────────────────────────────────
//  CHAPTER 9A – THE ITERATOR PATTERN
// ─────────────────────────────────────────────────────────────────────────────
PrintHeader("CHAPTER 9A – THE ITERATOR PATTERN", '=');
Console.WriteLine(
    """
    The Iterator Pattern provides a way to access the elements of an aggregate
    object sequentially without exposing its underlying representation.

    Design Principle: Single Responsibility — separate the job of iterating a
    collection from the collection's own data-management concerns.

    Key participants:
      • Iterator  — defines HasNext() and Next() for sequential traversal
      • Aggregate — creates an iterator for its backing data structure
      • Client    — drives the iterator; never touches the backing structure
    """);

// ─────────────────────────────────────────────────────────────────────────────
//  PART 1 – The Problem: Two Restaurants, Two Data Structures
// ─────────────────────────────────────────────────────────────────────────────
PrintHeader("PART 1: The Problem — Different Backing Data Structures", '-');
Console.WriteLine(
    """
    Two restaurants merge into one:
      • PancakeHouseMenu  stores items in a  List<MenuItem>      (dynamic)
      • DinerMenu         stores items in a  MenuItem?[]         (fixed-size array)

    Without the Iterator Pattern the Waitress must know both structures and
    iterate each one differently — violating encapsulation and the Open/Closed
    Principle.

    WITH the Iterator Pattern:
      • Both menus implement  IMenu.CreateIterator()
      • Waitress only talks to  IIterator<MenuItem>  — structure is hidden
      • Adding a third restaurant requires zero changes to Waitress
    """);

var pancakeMenu = new PancakeHouseMenu();
var dinerMenu = new DinerMenu();
var waitress = new Waitress(pancakeMenu, dinerMenu);

Console.WriteLine("Printing all menus via the custom IIterator:");
waitress.PrintMenu();

// ─────────────────────────────────────────────────────────────────────────────
//  PART 2 – Filtering: Vegetarian Menu
// ─────────────────────────────────────────────────────────────────────────────
PrintHeader("PART 2: Filtering — Vegetarian Items Across All Menus", '-');
Console.WriteLine(
    """
    The Waitress can traverse every menu using its iterator and selectively
    print vegetarian items — without knowing or caring about backing structures.
    """);

waitress.PrintVegetarianMenu();

// ─────────────────────────────────────────────────────────────────────────────
//  PART 3 – .NET IEnumerable<T>: The Built-In Iterator Pattern
// ─────────────────────────────────────────────────────────────────────────────
PrintHeader("PART 3: IEnumerable<T> — The .NET Standard Iterator", '-');
Console.WriteLine(
    """
    .NET ships a built-in iterator pattern via IEnumerable<T> / IEnumerator<T>.
    These types map directly to the Iterator Pattern:
      • IEnumerable<T>  = Aggregate  (produces an enumerator on demand)
      • IEnumerator<T>  = Iterator   (MoveNext() / Current)
      • foreach         = client code that drives the enumerator automatically

    All three menus now implement IEnumerable<MenuItem>:
      • PancakeHouseMenu  — List-backed       → delegates to List.GetEnumerator()
      • DinerMenu         — array-backed      → uses Take(_count).OfType<MenuItem>()
      • CafeMenu          — Dictionary-backed → iterates Dictionary.Values

    WaitressV2 accepts any IEnumerable<MenuItem> — it never calls CreateIterator()
    and never knows what sits behind the data.
    """);

var cafeMenu = new CafeMenu();
var waitressV2 = new WaitressV2(
    ("Pancake House Menu — Breakfast", pancakeMenu),
    ("Diner Menu — Lunch", dinerMenu),
    ("Cafe Menu — Dinner", cafeMenu)
);

Console.WriteLine("Printing all menus via IEnumerable<T> / foreach:");
waitressV2.PrintMenu();

Console.WriteLine();
Console.WriteLine("Filtering vegetarian items via LINQ Where():");
waitressV2.PrintVegetarianMenu();

// ─────────────────────────────────────────────────────────────────────────────
//  Summary
// ─────────────────────────────────────────────────────────────────────────────
Console.WriteLine();
PrintHeader("SUMMARY", '=');
Console.WriteLine(
    """
    ┌────────────────────────────────────────────────────────────────────────────┐
    │                     Iterator Pattern — Key Points                          │
    ├────────────────────────────────────────────────────────────────────────────┤
    │  • Encapsulates traversal so the client never sees the backing structure   │
    │  • Supports the Single Responsibility Principle — the collection manages   │
    │    its data; the iterator manages traversal                                │
    │  • Provides a uniform interface for iterating ANY aggregate object         │
    │  • .NET's IEnumerable<T> / IEnumerator<T> IS the Iterator Pattern          │
    │  • foreach is syntactic sugar over MoveNext() + Current — exact match      │
    │  • LINQ (Where, Select, …) works on any IEnumerable — free filtering!      │
    └────────────────────────────────────────────────────────────────────────────┘
    """);

static void PrintHeader(string title, char separator)
{
    string line = new string(separator, 79);
    Console.WriteLine();
    Console.WriteLine(line);
    Console.WriteLine($"  {title}");
    Console.WriteLine(line);
}

