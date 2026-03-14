using Ch10_TheStatePattern.Legacy;
using Ch10_TheStatePattern.Models;

// -----------------------------------------------------------------------------
//  CHAPTER 10 - THE STATE PATTERN
// -----------------------------------------------------------------------------
PrintHeader("CHAPTER 10 - THE STATE PATTERN", '=');
Console.WriteLine(
    """
    The State Pattern allows an object to alter its behavior when its internal
    state changes. The object appears to change its class.

    We will walk through the same sequence from the book:
      1. Legacy implementation using conditionals and integer flags
      2. Refactor to the State Pattern with concrete state objects
      3. Extend behavior with WinnerState (two gumballs)
    """);

// -----------------------------------------------------------------------------
//  PART 1 - Legacy Version (Before State Pattern)
// -----------------------------------------------------------------------------
PrintHeader("PART 1: Legacy Gumball Machine (Conditionals)", '-');
Console.WriteLine(
    """
    This version keeps behavior in one class and branches on integer state.
    It works, but behavior is tangled and gets harder to maintain as rules grow.
    """);

var legacyMachine = new GumballMachineLegacy(3);
Console.WriteLine(legacyMachine);

legacyMachine.InsertQuarter();
legacyMachine.TurnCrank();
Console.WriteLine(legacyMachine);

legacyMachine.InsertQuarter();
legacyMachine.EjectQuarter();
legacyMachine.TurnCrank();
Console.WriteLine(legacyMachine);

legacyMachine.InsertQuarter();
legacyMachine.TurnCrank();
legacyMachine.InsertQuarter();
legacyMachine.TurnCrank();
Console.WriteLine(legacyMachine);

// -----------------------------------------------------------------------------
//  PART 2 - State Pattern Version
// -----------------------------------------------------------------------------
PrintHeader("PART 2: State Pattern Refactor", '-');
Console.WriteLine(
    """
    Behavior is now distributed to dedicated state classes:
      - NoQuarterState
      - HasQuarterState
      - SoldState
      - SoldOutState
      - WinnerState (book extension)

    GumballMachine delegates every action to the current state object.
    """);

var machine = new GumballMachine(10);
Console.WriteLine(machine);

for (int i = 0; i < 5; i++)
{
    machine.InsertQuarter();
    machine.TurnCrank();
    Console.WriteLine(machine);
}

// -----------------------------------------------------------------------------
//  PART 3 - Sold Out + Refill Scenario
// -----------------------------------------------------------------------------
PrintHeader("PART 3: Sold Out and Refill", '-');
Console.WriteLine(
    """
    The machine eventually reaches SoldOutState. Then we refill and continue.
    """);

while (machine.Count > 0)
{
    machine.InsertQuarter();
    machine.TurnCrank();
}

Console.WriteLine(machine);

machine.Refill(5);
Console.WriteLine(machine);

machine.InsertQuarter();
machine.TurnCrank();
Console.WriteLine(machine);

// -----------------------------------------------------------------------------
//  Summary
// -----------------------------------------------------------------------------
PrintHeader("SUMMARY", '=');
Console.WriteLine(
    """
    Key takeaways:
      - Legacy approach centralizes logic and scales poorly with new rules.
      - State Pattern localizes behavior per state and removes giant if/switch blocks.
      - Adding WinnerState required introducing a new class, not editing every method.
      - This follows Open/Closed Principle and keeps transitions explicit.
    """);

static void PrintHeader(string title, char separator)
{
    string line = new string(separator, 79);
    Console.WriteLine();
    Console.WriteLine(line);
    Console.WriteLine($"  {title}");
    Console.WriteLine(line);
}
