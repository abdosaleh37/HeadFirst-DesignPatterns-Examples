# Chapter 9A: The Iterator Pattern

## Pattern Definition

**The Iterator Pattern** provides a way to access the elements of an aggregate
object sequentially without exposing its underlying representation.

## The Problem

Two restaurants merge under one roof:

| Restaurant | Data Structure | Items |
|---|---|---|
| Pancake House | `List<MenuItem>` | Breakfast items |
| Diner | `MenuItem?[]` (fixed array) | Lunch items |

Without the Iterator Pattern, the `Waitress` must know both data structures and
iterate each one differently:

```csharp
// Without Iterator — Waitress knows too much
void PrintMenu(PancakeHouseMenu pancake, DinerMenu diner)
{
    List<MenuItem> breakfastItems = pancake.GetItems();
    for (int i = 0; i < breakfastItems.Count; i++)
        Console.WriteLine(breakfastItems[i]);

    MenuItem?[] lunchItems = diner.GetItems();
    for (int i = 0; i < lunchItems.Length; i++)
        if (lunchItems[i] is not null)
            Console.WriteLine(lunchItems[i]);
}
```

**Problems:**
1. **Broken encapsulation** — the Waitress must know the backing structure of each menu
2. **Violates Open/Closed Principle** — adding a third restaurant requires editing `Waitress`
3. **Code duplication** — two separate loops for the same conceptual operation

## The Solution: Iterator Pattern

Define a common `IIterator<T>` interface. Each menu creates its own iterator that
hides its backing structure behind `HasNext()` / `Next()`:

```csharp
public interface IIterator<T>
{
    bool HasNext();
    T Next();
}
```

Each menu implements `IMenu` and returns its own iterator:

```csharp
// PancakeHouseMenu — List-backed
public IIterator<MenuItem> CreateIterator()
    => new PancakeHouseMenuIterator(_items);   // _items is List<MenuItem>

// DinerMenu — array-backed
public IIterator<MenuItem> CreateIterator()
    => new DinerMenuIterator(_items);          // _items is MenuItem?[]
```

The `Waitress` now only talks to `IIterator<MenuItem>` — the backing structure is
completely hidden:

```csharp
private static void PrintItems(IIterator<MenuItem> iterator)
{
    while (iterator.HasNext())
        Console.WriteLine(iterator.Next());
}
```

Adding the `CafeMenu` (Dictionary-backed) requires **zero changes** to `Waitress`.

## Design Principle Applied

**Single Responsibility Principle** — a class should have only one reason to change.

Before: `DinerMenu` managed its data *and* had to be understood externally for iteration.  
After: `DinerMenu` manages its data. `DinerMenuIterator` manages iteration. Two separate
reasons to change → two separate classes.

## Example 1: Custom IIterator (PART 1 & 2)

The `Waitress` accepts any `IMenu` and uses `CreateIterator()` uniformly:

```
PancakeHouseMenu  →  PancakeHouseMenuIterator  (over List<MenuItem>)
DinerMenu         →  DinerMenuIterator         (over MenuItem?[])
```

The Waitress can also filter across all menus without touching backing structures:

```csharp
public void PrintVegetarianMenu()
{
    foreach (var menu in _menus)
    {
        var iterator = menu.CreateIterator();
        while (iterator.HasNext())
        {
            var item = iterator.Next();
            if (item.IsVegetarian)
                Console.WriteLine(item);
        }
    }
}
```

## Example 2: .NET's Built-In Iterator — IEnumerable\<T\> (PART 3)

.NET ships the Iterator Pattern as `IEnumerable<T>` / `IEnumerator<T>`:

| Iterator Pattern | .NET Equivalent |
|---|---|
| `Aggregate.CreateIterator()` | `IEnumerable<T>.GetEnumerator()` |
| `IIterator<T>` | `IEnumerator<T>` |
| `HasNext()` | `MoveNext()` |
| `Next()` | `Current` |
| Client driving the loop | `foreach` |

All three menus implement `IEnumerable<MenuItem>` over different structures:

```csharp
// PancakeHouseMenu — delegates straight to List
public IEnumerator<MenuItem> GetEnumerator() => _items.GetEnumerator();

// DinerMenu — slices the fixed array to actual count
public IEnumerator<MenuItem> GetEnumerator()
    => _items.Take(_count).OfType<MenuItem>().GetEnumerator();

// CafeMenu — iterates Dictionary values
public IEnumerator<MenuItem> GetEnumerator() => _items.Values.GetEnumerator();
```

`WaitressV2` accepts any `IEnumerable<MenuItem>` and uses `foreach` and LINQ freely:

```csharp
foreach (var item in items)           // foreach drives the enumerator
    Console.WriteLine(item);

foreach (var item in items.Where(i => i.IsVegetarian))  // LINQ filters freely
    Console.WriteLine(item);
```

## Class Diagram

```
     ┌──────────────────────────────┐
     │     «interface» IIterator<T> │
     ├──────────────────────────────┤
     │ + HasNext() : bool           │
     │ + Next() : T                 │
     └──────────────────────────────┘
                    ▲
      ┌─────────────┴──────────────┐
      │                            │
┌─────────────────────┐   ┌────────────────────────┐
│ PancakeHouseMenu    │   │  DinerMenuIterator     │
│ Iterator            │   │  (over MenuItem?[])    │
│ (over List<T>)      │   └────────────────────────┘
└─────────────────────┘

     ┌────────────────────────────────┐
     │      «interface» IMenu         │
     ├────────────────────────────────┤
     │ + MenuName : string            │
     │ + CreateIterator()             │
     └────────────────────────────────┘
                    ▲
      ┌─────────────┴──────────────┐
      │                            │
┌──────────────────┐   ┌──────────────────┐
│ PancakeHouseMenu │   │    DinerMenu     │
│ (List-backed)    │   │  (Array-backed)  │
└──────────────────┘   └──────────────────┘

     ┌──────────────────────────────┐
     │          Waitress            │
     ├──────────────────────────────┤
     │ - _menus : IMenu[]           │
     │ + PrintMenu()                │   uses IIterator<MenuItem>
     │ + PrintVegetarianMenu()      │
     └──────────────────────────────┘

     ┌──────────────────────────────┐
     │          WaitressV2          │
     ├──────────────────────────────┤
     │ + PrintMenu()                │   uses IEnumerable<MenuItem>
     │ + PrintVegetarianMenu()      │
     └──────────────────────────────┘
```

## Project Structure

```
Ch9_A_TheIteratorPattern/
├── Interfaces/
│   ├── IIterator.cs               ← Custom iterator interface (HasNext / Next)
│   └── IMenu.cs                   ← Aggregate interface (CreateIterator)
├── Models/
│   └── MenuItem.cs                ← Leaf data object (name, price, vegetarian)
├── Iterators/
│   ├── PancakeHouseMenuIterator.cs ← Iterates List<MenuItem>
│   └── DinerMenuIterator.cs        ← Iterates MenuItem?[] (fixed array)
├── Menus/
│   ├── PancakeHouseMenu.cs        ← Breakfast menu; List-backed; IMenu + IEnumerable
│   ├── DinerMenu.cs               ← Lunch menu; Array-backed; IMenu + IEnumerable
│   └── CafeMenu.cs                ← Dinner menu; Dictionary-backed; IEnumerable only
├── Client/
│   ├── Waitress.cs                ← Uses custom IIterator<MenuItem>
│   └── WaitressV2.cs              ← Uses .NET IEnumerable<MenuItem>
└── Program.cs                     ← Demo: Parts 1-3
```
