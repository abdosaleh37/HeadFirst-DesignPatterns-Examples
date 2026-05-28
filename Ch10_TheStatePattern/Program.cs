using Ch10_TheStatePattern.Legacy;
using Ch10_TheStatePattern.Models;

PrintSection("Chapter 10 - State Pattern");

PrintSection("Legacy (Conditional)");
var legacyMachine = new GumballMachineLegacy(3);
PrintMachine(legacyMachine);

Step("Insert quarter", legacyMachine.InsertQuarter, legacyMachine);
Step("Turn crank", legacyMachine.TurnCrank, legacyMachine);

Step("Insert quarter", legacyMachine.InsertQuarter, legacyMachine);
Step("Eject quarter", legacyMachine.EjectQuarter, legacyMachine);
Step("Turn crank", legacyMachine.TurnCrank, legacyMachine);

PrintSection("State Pattern");
var machine = new GumballMachine(5);
PrintMachine(machine);

Step("Insert quarter", machine.InsertQuarter, machine);
Step("Turn crank", machine.TurnCrank, machine);

Step("Insert quarter", machine.InsertQuarter, machine);
Step("Turn crank", machine.TurnCrank, machine);

Step("Refill", () => machine.Refill(2), machine);
Step("Insert quarter", machine.InsertQuarter, machine);
Step("Turn crank", machine.TurnCrank, machine);

static void PrintSection(string title)
{
    Console.WriteLine();
    Console.WriteLine(new string('-', 60));
    Console.WriteLine(title);
    Console.WriteLine(new string('-', 60));
}

static void Step(string label, Action action, object machine)
{
    Console.WriteLine();
    Console.WriteLine($"Action: {label}");
    action();
    Console.WriteLine(machine);
}

static void PrintMachine(object machine) => Console.WriteLine(machine);
