# Chapter 1 — Strategy Pattern

> *"Define a family of algorithms, encapsulate each one, and make them interchangeable."*  
> — Design Patterns: Elements of Reusable Object-Oriented Software

## Intent

The Strategy pattern defines stable contracts for volatile behavior. In this chapter, duck behavior varies (flying and quacking), while the duck model itself remains stable. By delegating behavior to interchangeable strategy objects, the design supports extension and runtime variation without subclass explosion.

## Also Known As

Policy Pattern.

## Motivation

The duck simulator begins with inheritance, where all ducks inherit `Fly()` and `Quack()` from a base class. This quickly fails because some ducks do not fly (`ModelDuck`, decoys) and others quack differently (or not at all). Overriding methods in many subclasses leads to duplication and fragile maintenance.

Strategy extracts these changing algorithms into focused classes (`FlyWithWings`, `FlyNoWay`, `FlyRocketPowered`, `QuackSound`, `Squeak`, `MuteQuack`) and composes them into `Duck`.

## Chapter Summary (From the Book)

Chapter 1 starts with a common design trap: relying on inheritance for behavior reuse. The initial `Duck` hierarchy looks clean, but every change in behavior forces edits across many subclasses. Requirements like "some ducks can't fly" or "change behavior at runtime" expose the rigidity.

The chapter demonstrates why interface-only refactors still fall short. While interfaces avoid incorrect inherited behavior, they push duplicated code into each concrete class and still don't support clean behavior reuse.

The solution is composition over inheritance. The book introduces Strategy by separating what changes (algorithms) from what stays the same (duck abstraction). `Duck` delegates behavior to composed objects through interfaces, and clients can swap implementations at runtime.

Core takeaway: **identify variation points early and encapsulate them behind abstractions**.

## Applicability

- Multiple classes differ primarily by one or two behavioral dimensions.
- Behavior needs to change at runtime (feature toggles, mode switches, dynamic composition).
- Large conditional blocks select one of several algorithm variants.
- You want to satisfy Open/Closed Principle for behavior extension.

## Structure

```text
Duck (Context)
 +- IFlyBehavior   -> FlyWithWings | FlyNoWay | FlyRocketPowered
 +- IQuackBehavior -> QuackSound   | Squeak   | MuteQuack
```

## Participants

| Role | Class in This Project | Responsibility |
|---|---|---|
| Context | `Duck` | Holds behavior references and delegates `PerformFly()` / `PerformQuack()` |
| Concrete Context | `MallardDuck`, `ModelDuck` | Selects sensible default strategy composition |
| Strategy | `IFlyBehavior`, `IQuackBehavior` | Defines interchangeable algorithm contracts |
| Concrete Strategy | `FlyWithWings`, `FlyNoWay`, `FlyRocketPowered`, `QuackSound`, `Squeak`, `MuteQuack` | Implements specific behavior variants |
| Client | `Program` | Creates contexts and optionally replaces strategies at runtime |

## Collaborations

1. The client creates a concrete `Duck`.
2. The duck constructor wires default behavior objects.
3. `PerformFly()` and `PerformQuack()` delegate directly to strategy interfaces.
4. The client may replace strategy instances (e.g., rocket-powered flight).
5. The duck behavior changes without changing duck class code.

## Consequences

**Benefits**

- Runtime behavior switching with no context subclass changes.
- High reuse of behavior objects across many contexts.
- Better testability (strategies can be tested in isolation).
- Cleaner separation of concerns.

**Liabilities**

- Increases number of small classes.
- Clients must understand available strategy options.
- Slight indirection cost due to delegation.

## Implementation Notes

- `Duck` exposes settable `FlyBehavior` and `QuackBehavior` properties for runtime replacement.
- Concrete duck constructors choose default behavior composition.
- Strategies are stateless in this chapter, so sharing instances would also be possible.
- Behavior interfaces keep chapter code aligned with .NET's polymorphic design style.

## Sample Code

```csharp
Duck model = new ModelDuck();
model.PerformFly();

model.FlyBehavior = new FlyRocketPowered();
model.PerformFly();
```

## Known Uses

- `IComparer<T>` and custom comparer injection in sorting APIs.
- Authentication handlers selected by scheme in ASP.NET Core.
- Pluggable serialization/compression providers selected at runtime.

## Related Patterns

- **State**: similar structure, but state transitions are internal to context behavior.
- **Decorator**: composes responsibilities around objects rather than swapping algorithms.
- **Factory Method**: often used to create strategy objects.

## Project File Map

```text
Ch01_TheStrategyPattern/
+- Program.cs
+- Ch01_TheStrategyPattern.csproj
+- Interfaces/
|  +- IFlyBehavior.cs
|  +- IQuackBehavior.cs
+- Behaviors/
|  +- FlyBehaviors/
|  +- QuackBehaviors/
+- Models/
   +- Duck.cs
   +- MallardDuck.cs
   +- ModelDuck.cs
```

## How to Run

`dotnet run --project Ch01_TheStrategyPattern/Ch01_TheStrategyPattern.csproj`
