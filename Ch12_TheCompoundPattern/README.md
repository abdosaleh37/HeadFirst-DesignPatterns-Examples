# Chapter 12 - Compound Pattern

> "A compound pattern combines multiple patterns into a larger solution."  
> - Head First Design Patterns (paraphrase)

## Intent
Compose multiple patterns to solve a broader design problem while keeping each concern separate.

## Also Known As
Pattern composition.

## Motivation
The duck simulator requires adapters, decorators, factories, composites, and observers at once. The MVC example shows a larger architectural composition where Model, View, and Controller remain decoupled.

## Chapter Summary (From the Book)
Chapter 12 demonstrates that real systems rarely use a single pattern in isolation. The duck simulator combines multiple patterns to address different forces at the same time, while MVC shows how an architecture can be built from smaller pattern roles.

The lesson is to compose patterns intentionally rather than inventing a single "mega-pattern."

## Applicability
- Use when one pattern does not cover all design forces in a system.
- Use when different responsibilities can be isolated by different patterns.
- Use to keep collaborations flexible as requirements grow.

## Structure
```
Compound = Pattern A + Pattern B + Pattern C
```

## Participants
| Role | Class in This Project | Responsibility |
| --- | --- | --- |
| Adapter | `GooseAdapter` | Lets a goose act as a duck. |
| Decorator | `QuackCounter` | Adds quack counting. |
| Abstract Factory | `CountingDuckFactory` | Creates wrapped ducks. |
| Composite | `Flock` | Treats groups and individuals uniformly. |
| Observer | `Quackologist` | Listens for quack events. |
| MVC Model | `BeatModel` | Owns beat state and notifies observers. |
| MVC View | `ConsoleDJView` | Renders model state and forwards actions. |
| MVC Controller | `BeatController` | Coordinates user actions. |

## Collaborations
The duck simulator combines adapters, decorators, factories, composites, and observers so all quackers can be created, grouped, and monitored uniformly. The MVC section uses observer-based updates between the model and view while the controller drives actions.

## Consequences
- Composed patterns keep each responsibility focused and replaceable.
- The system becomes easier to extend with new roles.
- The number of types increases, so naming and organization matter.

## Implementation Notes
- `CountingDuckFactory` ensures all created ducks are decorated with `QuackCounter`.
- `Flock` forwards `Quack()` to all child quackers, including nested flocks.
- The MVC sample keeps view and model communication decoupled through interfaces.

## Sample Code
```csharp
IAbstractDuckFactory factory = new CountingDuckFactory();
IQuackable duck = factory.CreateMallardDuck();
IQuackable gooseDuck = new GooseAdapter(new Goose());

var flock = new Flock();
flock.Add(duck);
flock.Add(gooseDuck);
flock.Quack();
```

## Known Uses
- MVC in web and desktop frameworks.
- Systems that combine multiple patterns such as factories + decorators + observers.

## Related Patterns
- All patterns used in the composition are related by collaboration rather than inheritance.

## Project File Map
```
Ch12_TheCompoundPattern/
  Ch12_TheCompoundPattern.csproj
  Program.cs
  Adapters/
  Composites/
  Decorators/
  Factories/
  Interfaces/
  Models/
  Observers/
```

## How to Run
`dotnet run --project Ch12_TheCompoundPattern/Ch12_TheCompoundPattern.csproj`
