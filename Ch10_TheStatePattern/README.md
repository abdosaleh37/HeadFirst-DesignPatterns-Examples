# Chapter 10: The State Pattern

## Pattern Definition

**The State Pattern** allows an object to alter its behavior when its internal
state changes. The object appears to change its class.

## The Problem

The classic gumball machine starts with all behavior in a single class and a set
of state flags (or constants) like:

- `SOLD_OUT`
- `NO_QUARTER`
- `HAS_QUARTER`
- `SOLD`

A typical method grows into condition-heavy code:

```csharp
public void TurnCrank()
{
    if (_state == HasQuarter)
    {
        Console.WriteLine("You turned...");
        _state = Sold;
        Dispense();
    }
    else if (_state == NoQuarter)
    {
        Console.WriteLine("You turned, but there's no quarter.");
    }
    // ...more branches...
}
```

**Problems with this approach:**

1. Long `if/else` or `switch` blocks become harder to maintain
2. Transition rules are scattered across multiple methods
3. Adding new behavior requires editing existing conditionals everywhere
4. Bugs appear easily when one transition is forgotten

## The Solution: State Pattern

**Design Principle:** *Encapsulate what varies.*

Each state is moved into its own class behind a common interface.

```csharp
public interface IGumballState
{
    void InsertQuarter();
    void EjectQuarter();
    void TurnCrank();
    void Dispense();
}
```

The context (`GumballMachine`) delegates every action to the current state:

```csharp
public void InsertQuarter() => State.InsertQuarter();
public void EjectQuarter() => State.EjectQuarter();

public void TurnCrank()
{
    State.TurnCrank();
    State.Dispense();
}
```

Now behavior changes by swapping the active state object.

## Design Principles Applied

### 1. Encapsulate What Varies

- State-specific behavior lives in concrete state classes
- The context no longer contains giant conditional logic

### 2. Open/Closed Principle

- New states are added as new classes
- Existing stable state classes remain untouched

### 3. Single Responsibility

- Each state class handles one state's behavior and transitions

### 4. Composition Over Inheritance

- `GumballMachine` has a state object and delegates to it

## Class Diagram (Text)

```
┌─────────────────────────┐
│     IGumballState       │
├─────────────────────────┤
│ + InsertQuarter()       │
│ + EjectQuarter()        │
│ + TurnCrank()           │
│ + Dispense()            │
└─────────────────────────┘
                 ▲
                 │ implements
    ┌─────────┼──────────┬──────────┬──────────┬──────────┐
    │         │          │          │          │          │
┌──┴────────┐┌┴─────────┐┌┴────────┐┌┴────────┐┌┴────────┐
│NoQuarter  ││HasQuarter││Sold     ││SoldOut  ││Winner   │
│State      ││State     ││State    ││State    ││State    │
└───────────┘└──────────┘└─────────┘└─────────┘└─────────┘

┌───────────────────────────────────────────────┐
│               GumballMachine                  │
├───────────────────────────────────────────────┤
│ - State : IGumballState                       │
│ - Count : int                                 │
├───────────────────────────────────────────────┤
│ + InsertQuarter()                             │
│ + EjectQuarter()                              │
│ + TurnCrank()                                 │
│ + SetState(state)                             │
│ + ReleaseBall()                               │
└───────────────────────────────────────────────┘
```

## Implementation Details

### State Interface

- `Interfaces/IGumballState.cs`

Defines the operations each state must support.

### Context

- `Models/GumballMachine.cs`

Owns all state objects, tracks inventory, and delegates requests to current state.

### Concrete States

- `States/NoQuarterState.cs`
- `States/HasQuarterState.cs`
- `States/SoldState.cs`
- `States/SoldOutState.cs`
- `States/WinnerState.cs`

`WinnerState` implements the chapter extension where a customer can receive two
balls on a lucky turn.

### Legacy Baseline

- `Legacy/GumballMachineLegacy.cs`

Shows the pre-refactor style with conditional logic to compare against the State
Pattern implementation.

## Program Walkthrough

`Program.cs` demonstrates:

1. Legacy implementation with conditionals
2. State Pattern implementation with delegated behavior
3. Sold-out and refill flow
4. Winner-state behavior opportunities

Run this chapter:

```powershell
dotnet run --project Ch10_TheStatePattern/Ch10_TheStatePattern.csproj
```

## Benefits of the State Pattern

✅ Cleaner behavior logic without central conditionals

✅ Easier extensions by adding new states

✅ Explicit transitions captured close to each state's behavior

✅ Better readability and maintainability as rules grow

## Project Structure

```
Ch10_TheStatePattern/
|-- Interfaces/
|   `-- IGumballState.cs
|-- Legacy/
|   `-- GumballMachineLegacy.cs
|-- Models/
|   `-- GumballMachine.cs
|-- States/
|   |-- NoQuarterState.cs
|   |-- HasQuarterState.cs
|   |-- SoldState.cs
|   |-- SoldOutState.cs
|   `-- WinnerState.cs
|-- Program.cs
`-- README.md
```
