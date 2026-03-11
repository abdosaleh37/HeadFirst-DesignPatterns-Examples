# Chapter 8: The Template Method Pattern

## Pattern Definition

**The Template Method Pattern** defines the skeleton of an algorithm in a method, deferring some steps to subclasses. Template Method lets subclasses redefine certain steps of an algorithm without changing the algorithm's structure.

## The Problem

You're building a coffee and tea application. Both beverages follow almost the same recipe:

| Step | Tea | Coffee |
|------|-----|--------|
| 1. Boil water | same | same |
| 2. Brew | steep tea | drip through filter |
| 3. Pour in cup | same | same |
| 4. Add condiments | add lemon | add sugar & milk |

**Without the Template Method Pattern:**

```csharp
class Tea
{
    void PrepareRecipe()
    {
        BoilWater();
        SteepTeaBag();    // ← Tea-specific
        PourInCup();
        AddLemon();       // ← Tea-specific
    }
}

class Coffee
{
    void PrepareRecipe()
    {
        BoilWater();
        DripThroughFilter(); // ← Coffee-specific
        PourInCup();
        AddSugarAndMilk();   // ← Coffee-specific
    }
}
```

**Problems:**
1. **Code duplication** — `BoilWater()` and `PourInCup()` are copied in both classes
2. **No single place to change** — modifying the algorithm requires changing both classes
3. **No enforced structure** — each class can reorder the steps freely

## The Solution: Template Method Pattern

Move the invariant steps into a base class and let subclasses fill in only the parts that differ.

```csharp
public abstract class CaffeineBeverage
{
    // ── Template Method ────────────────────────────────────────
    public void PrepareRecipe()  // Non-virtual — structure is FIXED
    {
        BoilWater();
        Brew();               // abstract — subclass fills in
        PourInCup();
        if (CustomerWantsCondiments())  // hook guards this step
            AddCondiments();  // abstract — subclass fills in
    }

    protected abstract void Brew();
    protected abstract void AddCondiments();

    private void BoilWater()    => Console.WriteLine("Boiling water");
    private void PourInCup()   => Console.WriteLine("Pouring into cup");

    // Hook — subclasses MAY override, default returns true
    protected virtual bool CustomerWantsCondiments() => true;
}
```

## Design Principles Applied

### 1. The Hollywood Principle — "Don't call us, we'll call you."

High-level components call low-level components, not the other way around.

- `CaffeineBeverage` (high-level) calls `Brew()` and `AddCondiments()` on the subclass
- `Tea` and `Coffee` (low-level) **never** call the base class — they just implement the steps

This prevents **dependency rot** — a tangled mess where low-level and high-level components all call each other.

### 2. Favor Composition + Inheritance appropriately

The Template Method Pattern uses **inheritance** purposefully here: the algorithm skeleton is inherited and shared. Hooks allow optional customization without requiring it.

### 3. Open/Closed Principle

- **Open for extension**: Add a new beverage by subclassing — no changes to existing code
- **Closed for modification**: The algorithm skeleton in `PrepareRecipe()` is not modified

## Class Diagram

```
          ┌─────────────────────────────────────┐
          │     CaffeineBeverage  (abstract)    │
          ├─────────────────────────────────────┤
          │ + PrepareRecipe()  ← Template Meth  │
          │ # Brew()  (abstract)                │
          │ # AddCondiments()  (abstract)       │
          │ - BoilWater()                       │
          │ - PourInCup()                       │
          │ # CustomerWantsCondiments()  (hook) │
          └─────────────────────────────────────┘
                         ▲
          ┌──────────────┴──────────────┐
          │                             │
  ┌──────────────┐             ┌──────────────────┐
  │     Tea      │             │     Coffee       │
  ├──────────────┤             ├──────────────────┤
  │ # Brew()     │             │ # Brew()         │
  │ # AddCond.() │             │ # AddCond.()     │
  └──────────────┘             └──────────────────┘

  ┌──────────────────┐         ┌──────────────────────┐
  │  TeaWithHook     │         │   CoffeeWithHook     │
  ├──────────────────┤         ├──────────────────────┤
  │ # Brew()         │         │ # Brew()             │
  │ # AddCond.()     │         │ # AddCond.()         │
  │ # CustomerWants()│         │ # CustomerWants()    │
  └──────────────────┘         └──────────────────────┘
```

## Hooks

A **hook** is a method declared in the abstract class that:
- Has a default (often empty or return-true) implementation
- **Can** be overridden by subclasses, but doesn't have to be
- Allows subclasses to hook into the algorithm at a specific point

```csharp
// In the abstract class — hook with default
protected virtual bool CustomerWantsCondiments() => true;

// In TeaWithHook — overrides hook to ask the user
protected override bool CustomerWantsCondiments()
{
    Console.Write("Would you like lemon with your tea (y/n)? ");
    string? answer = Console.ReadLine();
    return answer?.ToLower().StartsWith("y") ?? true;
}
```

**When to use a hook vs. an abstract method:**

| Situation | Use |
|-----------|-----|
| Step is **required** by the algorithm | `abstract` method |
| Step is **optional** or has a sensible default | `virtual` hook |

## Template Method in the Wild — `Array.Sort`

The Template Method Pattern is everywhere in frameworks. `Array.Sort()` is a perfect example:

```
Array.Sort()              ← Template method (sorting algorithm skeleton)
    │
    └── calls CompareTo() ← The step YOU fill in by implementing IComparable<T>
```

```csharp
public class Duck : IComparable<Duck>
{
    public int Weight { get; }

    // We fill in this "step" — lighter ducks sort first
    public int CompareTo(Duck? other) => Weight.CompareTo(other?.Weight);
}

Duck[] ducks = [ new Duck("Daffy", 8), new Duck("Dewey", 2), ... ];
Array.Sort(ducks);  // Calls Duck.CompareTo() at each comparison — Template Method!
```

## Hollywood Principle: Abstract Application Frame

A real-world framework demonstration — the framework calls your code, not the other way:

```
AbstractApplicationFrame.Run()   ← Framework's template method
    │
    ├── Initialize()  ← hook (optional, has default)
    ├── while (!IsDone()) Handle()  ← abstract, you fill in
    └── Cleanup()     ← hook (optional, has default)
```

Your application (`CountdownApp`) only implements `Handle()`, `IsDone()`, and optionally the hooks — it never calls `Run()` itself!

## Project Structure

```
Ch8_TheTemplatePattern/
├── Abstracts/
│   └── CaffeineBeverage.cs          ← Abstract class with template method
├── Beverages/
│   ├── Tea.cs                        ← Concrete: steeps, adds lemon
│   ├── Coffee.cs                     ← Concrete: filters, adds sugar & milk
│   ├── TeaWithHook.cs                ← Concrete: overrides hook to ask user
│   └── CoffeeWithHook.cs             ← Concrete: overrides hook to ask user
├── Sorting/
│   └── Duck.cs                       ← IComparable<Duck> — Array.Sort example
├── Frames/
│   ├── AbstractApplicationFrame.cs  ← Abstract frame (Hollywood Principle)
│   └── CountdownApp.cs              ← Concrete app plugged into the frame
└── Program.cs                        ← All demos
```

## Key Takeaways

| Concept | Description |
|---------|-------------|
| **Template Method** | Non-virtual method in the base class that defines the algorithm skeleton |
| **Abstract primitives** | `abstract` methods that subclasses must provide |
| **Hooks** | `virtual` methods with defaults — subclasses optionally override |
| **Hollywood Principle** | High-level components call low-level ones, never the reverse |
| **Code reuse** | Invariant steps live once in the base class, not copied in each subclass |

## Template Method vs Strategy Pattern

Both define a family of algorithms, but differ in how they do it:

| | Template Method | Strategy |
|-|-----------------|----------|
| **Mechanism** | Inheritance | Composition |
| **Algorithm defined** | In the base class (template) | In a separate strategy object |
| **Variation** | Subclasses override steps | Different strategy objects swapped in |
| **Relationship** | IS-A (subclass is a specialisation) | HAS-A (context has a strategy) |
| **Best when** | Steps vary but structure doesn't | Entire algorithm varies |
