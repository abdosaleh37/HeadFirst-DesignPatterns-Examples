# Chapter 8 - Template Method Pattern

> "Define the skeleton of an algorithm in an operation, deferring some steps to subclasses. Template Method lets subclasses redefine certain steps of an algorithm without changing the algorithm's structure."  
> - Design Patterns: Elements of Reusable Object-Oriented Software

## Intent
Define a fixed algorithm outline while allowing subclasses to override specific steps.

## Also Known As
N/A.

## Motivation
Tea and coffee share the same recipe steps but differ in the brewing and condiment steps. A template method keeps the shared sequence in one place and allows each beverage to supply only the varying steps.

## Chapter Summary (From the Book)
The chapter begins with duplicated algorithms across multiple beverage classes. The book consolidates the shared sequence in a base class, leaving subclasses to implement the steps that vary.

It then introduces hooks for optional steps and highlights the Hollywood Principle: the template method controls the sequence and calls subclass code rather than the other way around. Framework examples like sorting show how often this pattern appears in real APIs.

## Applicability
- Use when multiple classes share a common algorithm structure.
- Use when some steps must be fixed while others vary.
- Use to enforce an order of operations across implementations.

## Structure
```
+------------------------------+
| CaffeineBeverage             |
| + PrepareRecipe()            |
| # Brew()                     |
| # AddCondiments()            |
| # CustomerWantsCondiments()  |
+------------------------------+
              ^
              |
      +-------+-------+
      |               |
   Tea             Coffee
```

## Participants
| Role | Class in This Project | Responsibility |
| --- | --- | --- |
| Abstract Class | `CaffeineBeverage` | Defines the template method and hooks. |
| Concrete Class | `Tea`, `Coffee` | Implements required steps. |
| Hooked Class | `TeaWithHook`, `CoffeeWithHook` | Overrides the optional hook for condiments. |
| Framework Example | `Duck` | Implements `IComparable<T>` for `Array.Sort()`. |
| Framework Example | `AbstractApplicationFrame` | Calls template methods defined by subclasses. |
| Client | `Program` | Runs the demos. |

## Collaborations
The template method calls `Brew()` and `AddCondiments()` in a fixed order. Subclasses supply the step implementations and may override hook methods to influence optional behavior.

## Consequences
- Centralizes shared algorithm logic in one place.
- Enforces consistent ordering of steps.
- Uses inheritance, which can reduce flexibility compared to composition.
- Hooks can introduce branching logic that needs careful naming and defaults.

## Implementation Notes
- `PrepareRecipe()` is the template method in `CaffeineBeverage`.
- `CustomerWantsCondiments()` is the hook; `TeaWithHook` and `CoffeeWithHook` prompt the user.
- `Array.Sort()` relies on `Duck.CompareTo()` as the variable step.
- `AbstractApplicationFrame.Run()` shows the Hollywood Principle in a small framework.

## Sample Code
```csharp
public abstract class CaffeineBeverage
{
    public void PrepareRecipe()
    {
        BoilWater();
        Brew();
        PourInCup();
        if (CustomerWantsCondiments())
            AddCondiments();
    }

    protected abstract void Brew();
    protected abstract void AddCondiments();
    protected virtual bool CustomerWantsCondiments() => true;
}
```

## Known Uses
- `Array.Sort()` calls `IComparable<T>.CompareTo()` as a template step.
- ASP.NET Core middleware pipelines follow a template sequence with overridable steps.
- Framework base classes often expose hooks like `OnLoad()` or `OnPaint()`.

## Related Patterns
- Strategy varies the whole algorithm via composition.
- Factory Method can be implemented as a step in a template method.

## Project File Map
```
Ch08_TheTemplateMethodPattern/
  Ch08_TheTemplateMethodPattern.csproj
  Program.cs
  Abstracts/
  Beverages/
  Frames/
  Sorting/
```

## How to Run
`dotnet run --project Ch08_TheTemplateMethodPattern/Ch08_TheTemplateMethodPattern.csproj`
