# Chapter 9B: The Composite Pattern

## Pattern Definition

**The Composite Pattern** composes objects into tree structures to represent
part-whole hierarchies. It lets clients treat individual objects and compositions
of objects uniformly.

## The Problem

The merged restaurant now has three separate menus — and the Diner wants to add
a *sub-menu* (a Dessert Menu) nested inside its own lunch menu.

Without the Composite Pattern:

```csharp
// Client must distinguish menus from sub-menus manually
void PrintMenu(PancakeMenu p, DinerMenu d, CafeMenu c)
{
    PrintItems(p.CreateIterator());
    PrintItems(d.CreateIterator());
    // Now handle the dessert sub-menu somehow…
    if (d.HasDessertMenu())
        PrintItems(d.GetDessertMenu().CreateIterator());
    PrintItems(c.CreateIterator());
}
```

**Problems:**
1. **The client must know the tree** — it has to check for sub-menus explicitly
2. **Rigid structure** — adding another sub-menu requires changing the client
3. **No uniformity** — menus and menu items are treated as fundamentally different types

## The Solution: Composite Pattern

Build one abstract `MenuComponent` base that *both* `Menu` (composite) and
`MenuItem` (leaf) extend. The client calls `Print()` on any component — it
doesn't know or care whether it's about to print one item or an entire sub-tree.

```
MenuComponent  (abstract)
├── Menu       (composite) — holds a List<MenuComponent>, delegates Print() to each child
└── MenuItem   (leaf)      — has no children, prints itself directly
```

A `Menu` can contain both `MenuItem` leaves **and** other `Menu` composites. Adding a
Dessert Menu inside the Diner Menu is exactly the same operation as adding a `MenuItem`:

```csharp
dinerMenu.Add(dessertMenu);  // same call as dinerMenu.Add(new MenuItem(...))
```

The `Waitress` becomes trivially simple:

```csharp
public class Waitress
{
    private readonly MenuComponent _allMenus;
    public void PrintMenu() => _allMenus.Print();   // one line — handles ALL nesting
}
```

## Design Trade-Off: Transparency vs. Safety

`MenuComponent` exposes *both* leaf operations (`Name`, `Price`, `IsVegetarian`) and
composite operations (`Add`, `Remove`, `GetChild`) in a single type. This is the
**transparency** approach:

- **Advantage** — the client can treat all components identically; no casting needed
- **Trade-off** — leaf nodes must implement (and throw on) composite operations, and
  vice versa, which partially relaxes the Single Responsibility Principle

The alternative **safety** approach separates the two interfaces but forces the client
to check types — the book and this implementation favour transparency.

## Example 1: Full Menu Tree (PART 1)

The full tree is assembled once and printed with a single `waitress.PrintMenu()` call:

```
ALL MENUS
├── PANCAKE HOUSE MENU
│   ├── K&B's Pancake Breakfast  [V]
│   ├── Regular Pancake Breakfast
│   ├── Blueberry Pancakes  [V]
│   └── Waffles  [V]
├── DINER MENU
│   ├── Vegetarian BLT  [V]
│   ├── BLT
│   ├── Soup of the Day
│   ├── Hotdog
│   ├── Steamed Veggies and Brown Rice  [V]
│   ├── Pasta  [V]
│   └── DESSERT MENU          ← composite nested inside a composite
│       ├── Apple Pie  [V]
│       ├── Cheesecake  [V]
│       └── Sorbet  [V]
└── CAFE MENU
    ├── Veggie Burger and Air Fries  [V]
    ├── Soup of the Day
    └── Burrito  [V]
```

`Menu.Print()` recurses naturally — it calls `component.Print()` on every child,
and each child does the same if it is also a composite.

## Example 2: Uniform Treatment of Leaves and Composites (PART 2)

The defining power of the pattern: the same `Print()` call works on any node in the tree.

```csharp
// Print only the dessert sub-menu  (composite — recurses into 3 items)
dessertMenu.Print();

// Print a single leaf directly
var hotdog = new MenuItem("Hotdog", "...", false, 3.05);
hotdog.Print();
```

The client code is **identical** — no type checks, no casting, no special cases.

## Example 3: Dynamic Modification (PART 3)

Because `Menu` stores children in a `List<MenuComponent>`, the tree is fully dynamic.
`Add` and `Remove` take a `MenuComponent` regardless of whether it is a leaf or a
composite — another consequence of the uniform interface.

```csharp
cafeMenu.Add(new MenuItem("Late Night Special", "Two sliders and onion rings", false, 5.49));
dessertMenu.Remove(dessertMenu.GetChild(1));  // removes Cheesecake (index 1)
```

`Print()` renders the updated tree immediately — no rebuild step needed.

## Class Diagram

```
          ┌─────────────────────────────────────────┐
          │        MenuComponent  (abstract)        │
          ├─────────────────────────────────────────┤
          │ + Name : string  (virtual)              │
          │ + Description : string  (virtual)       │
          │ + Price : double  (virtual)             │
          │ + IsVegetarian : bool  (virtual)        │
          │ + Add(component)  (virtual — throws)    │
          │ + Remove(component)  (virtual — throws) │
          │ + GetChild(i)  (virtual — throws)       │
          │ + Print()  (abstract)                   │
          └─────────────────────────────────────────┘
                           ▲
            ┌──────────────┴───────────────┐
            │                              │
  ┌─────────────────┐            ┌──────────────────────┐
  │    MenuItem     │            │        Menu          │
  │    (Leaf)       │            │    (Composite)       │
  ├─────────────────┤            ├──────────────────────┤
  │ Name            │            │ - _components        │
  │ Description     │            │   List<MenuComponent>│
  │ Price           │            │ + Add()              │
  │ IsVegetarian    │            │ + Remove()           │
  │ + Print()       │            │ + GetChild()         │
  └─────────────────┘            │ + Print() ───────────► iterates children,
                                 └──────────────────────┘ calls each Print()

          ┌─────────────────────────────────┐
          │           Waitress              │
          ├─────────────────────────────────┤
          │ - _allMenus : MenuComponent     │
          │ + PrintMenu()                   │ → _allMenus.Print()
          └─────────────────────────────────┘
```

## Iterator + Composite Together

The Iterator and Composite Patterns appear in the same chapter because they
complement each other naturally:

- The **Composite Pattern** organises the *structure* of a menu tree
- The **Iterator Pattern** provides a way to *traverse* that tree externally

You can write an external iterator that walks the entire composite tree in any
order (depth-first, breadth-first, etc.) without changing the tree classes — the
two patterns are independent and compose cleanly.

## Project Structure

```
Ch9_B_TheCompositePattern/
├── Abstracts/
│   └── MenuComponent.cs    ← Abstract component (leaf + composite operations)
├── Models/
│   ├── MenuItem.cs         ← Leaf: has no children; prints one item
│   └── Menu.cs             ← Composite: holds List<MenuComponent>, delegates Print()
├── Client/
│   └── Waitress.cs         ← Holds root MenuComponent; calls Print() on it
└── Program.cs              ← Demo: Parts 1-3
```
