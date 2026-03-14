using Ch10_TheStatePattern.Interfaces;
using Ch10_TheStatePattern.Models;

namespace Ch10_TheStatePattern.States;

public sealed class NoQuarterState : IGumballState
{
    private readonly GumballMachine _gumballMachine;

    public NoQuarterState(GumballMachine gumballMachine) 
        => _gumballMachine = gumballMachine;

    public void InsertQuarter()
    {
        Console.WriteLine("You inserted a quarter.");
        _gumballMachine.SetState(_gumballMachine.HasQuarterState);
    }

    public void EjectQuarter() 
        => Console.WriteLine("You have not inserted a quarter.");

    public void TurnCrank() 
        => Console.WriteLine("You turned, but there is no quarter.");

    public void Dispense() 
        => Console.WriteLine("You need to pay first.");

    public override string ToString() => "waiting for quarter";
}
