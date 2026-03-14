# Chapter 10: The State Pattern

## Pattern Definition

**The State Pattern** allows an object to alter its behavior when its internal
state changes. The object will appear to change its class.

## The Problem

In the original Gumball Machine design, behavior is controlled by conditionals
on state flags (`soldOut`, `noQuarter`, `hasQuarter`, `sold`) inside a single
class.

```csharp
if (_state == HasQuarter)
{
    Console.WriteLine("You turned...");
    _state = Sold;
    Dispense();
}
```text

As transitions and rules grow, this leads to:

1. Long `if/else` or `switch` blocks that are hard to read
2. Scattered transition logic across many methods
3. Frequent edits to the same class when adding new behavior

## The Solution: State Pattern

Move state-dependent behavior into separate classes implementing a common
interface:

```csharp
public interface IGumballState
{
    void InsertQuarter();
    void EjectQuarter();
    void TurnCrank();
    void Dispense();
}
```text

The context (`GumballMachine`) keeps a reference to the current state and
forwards requests:

```csharp
public void InsertQuarter() => State.InsertQuarter();
public void EjectQuarter() => State.EjectQuarter();

public void TurnCrank()
{
    State.TurnCrank();
    State.Dispense();
}
```text

## State Classes in This Chapter

- `NoQuarterState`
- `HasQuarterState`
- `SoldState`
- `SoldOutState`
- `WinnerState` (book extension)

## Example Coverage (matching the chapter flow)

### 1. Legacy machine (before refactor)

`Legacy/GumballMachineLegacy.cs` demonstrates the classic conditional approach.

### 2. State pattern refactor

`Models/GumballMachine.cs` + state classes show the fully refactored design
where behavior is delegated to the current state object.

### 3. Winner extension

`WinnerState` models the "1 in 10 chance" rule where customers may receive
**two** gumballs for one quarter.

```csharp
int winner = Random.Shared.Next(10);
if (winner == 0 && _gumballMachine.Count > 1)
    _gumballMachine.SetState(_gumballMachine.WinnerState);
else
    _gumballMachine.SetState(_gumballMachine.SoldState);
```text

## Design Principles Applied

1. **Encapsulate what varies**: state-specific behavior moves into each state class
2. **Open/Closed Principle**: add new behavior by adding a new state class
3. **Single Responsibility**: each state class owns one state's behavior only
4. **Composition over inheritance**: machine composes a state object and delegates

## Class Diagram (text)

```
                +-------------------+
                |   IGumballState   |
                +-------------------+
                | InsertQuarter()   |
                | EjectQuarter()    |
                | TurnCrank()       |
                | Dispense()        |
                +-------------------+
                   ^   ^   ^   ^   ^
                   |   |   |   |   |
    +--------------+   |   |   |   +----------------+
    |                  |   |   |                    |
+-----------+   +------------+  +-----------+  +-----------+  +------------+
|NoQuarter  |   |HasQuarter  |  |Sold       |  |SoldOut    |  |Winner      |
+-----------+   +------------+  +-----------+  +-----------+  +------------+

                 +---------------------------------------------+
                 |               GumballMachine                |
                 +---------------------------------------------+
                 | - State : IGumballState                    |
                 | - Count : int                              |
                 | + InsertQuarter() / EjectQuarter()         |
                 | + TurnCrank()                              |
                 | + SetState(state)                          |
                 | + ReleaseBall()                            |
                 +---------------------------------------------+
```

## Program Demo

`Program.cs` runs:

1. Legacy implementation walkthrough
2. State-pattern implementation walkthrough
3. Sold-out and refill scenario
4. Winner behavior opportunities during crank turns

Run this chapter:

```powershell
dotnet run --project Ch10_TheStatePattern/Ch10_TheStatePattern.csproj
```

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
