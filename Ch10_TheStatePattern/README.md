# Chapter 10 - State Pattern

> "Allow an object to alter its behavior when its internal state changes. The object will appear to change its class."  
> - Design Patterns: Elements of Reusable Object-Oriented Software

## Intent
Encapsulate state-specific behavior and delegate behavior to the current state object.

## Also Known As
Objects for States.

## Motivation
The gumball machine has a small set of states, but each action changes behavior depending on the current state. Keeping all logic in a single class produces complex conditionals. State objects keep each behavior in one place and make transitions explicit.

## Chapter Summary (From the Book)
The chapter starts with a gumball machine implemented using integer flags and conditionals. This approach works but becomes hard to extend as rules grow.

Refactoring to the State Pattern moves each behavior into a dedicated state class and lets the machine delegate actions to the current state. The book extends the design with a `WinnerState` that dispenses two gumballs, showing how new behavior can be added without editing existing logic.

## Applicability
- Use when an object's behavior depends on its state and changes at runtime.
- Use when large conditional blocks repeat across multiple operations.
- Use to make state transitions explicit and testable.

## Structure
```
+------------------+       +------------------+
| Context          | ----> | State            |
| GumballMachine   |       | IGumballState    |
+------------------+       +------------------+
         ^
         |
  +------+------+-----+
  | NoQuarter | Sold |
  | HasQuarter| SoldOut |
  | Winner    |     |
```

## Participants
| Role | Class in This Project | Responsibility |
| --- | --- | --- |
| Context | `GumballMachine` | Holds current state and delegates actions. |
| State | `IGumballState` | Defines the state interface. |
| Concrete States | `NoQuarterState`, `HasQuarterState`, `SoldState`, `SoldOutState`, `WinnerState` | Implement state-specific behavior. |
| Legacy Baseline | `GumballMachineLegacy` | Shows the pre-refactor conditional approach. |

## Collaborations
The context forwards user actions to the current state object. The state object performs the action and decides which state to transition to next.

## Consequences
- Removes long conditional chains from the context.
- Makes state transitions explicit and easier to test.
- Adds more classes for each state.
- State objects can become tightly coupled to the context if not designed carefully.

## Implementation Notes
- `GumballMachine` owns all states and passes itself to each state for transitions.
- `WinnerState` dispenses two gumballs to demonstrate extension without changes to other states.
- `GumballMachineLegacy` mirrors the book's conditional baseline for comparison.

## Sample Code
```csharp
public interface IGumballState
{
    void InsertQuarter();
    void EjectQuarter();
    void TurnCrank();
    void Dispense();
}
```

## Known Uses
- Workflow engines that change behavior by phase.
- Network protocols with explicit connection states.
- UI components that vary behavior by mode.

## Related Patterns
- Strategy encapsulates algorithms, while State encapsulates state-dependent behavior.
- Flyweight can share state objects when they are immutable.

## Project File Map
```
Ch10_TheStatePattern/
  Ch10_TheStatePattern.csproj
  Program.cs
  Interfaces/
  Legacy/
  Models/
  States/
```

## How to Run
`dotnet run --project Ch10_TheStatePattern/Ch10_TheStatePattern.csproj`
