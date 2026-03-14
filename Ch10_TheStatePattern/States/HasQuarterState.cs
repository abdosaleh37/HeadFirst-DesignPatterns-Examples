using Ch10_TheStatePattern.Interfaces;
using Ch10_TheStatePattern.Models;

namespace Ch10_TheStatePattern.States;

public sealed class HasQuarterState : IGumballState
{
    private readonly GumballMachine _gumballMachine;

    public HasQuarterState(GumballMachine gumballMachine) 
        => _gumballMachine = gumballMachine;

    public void InsertQuarter() 
        => Console.WriteLine("You cannot insert another quarter.");

    public void EjectQuarter()
    {
        Console.WriteLine("Quarter returned.");
        _gumballMachine.SetState(_gumballMachine.NoQuarterState);
    }

    public void TurnCrank()
    {
        Console.WriteLine("You turned...");

        // Winner condition from the book's extension: around 1 in 10 turns wins.
        int winner = Random.Shared.Next(10);
        if (winner == 0 && _gumballMachine.Count > 1)
        {
            _gumballMachine.SetState(_gumballMachine.WinnerState);
        }
        else
        {
            _gumballMachine.SetState(_gumballMachine.SoldState);
        }
    }

    public void Dispense() 
        => Console.WriteLine("No gumball dispensed.");

    public override string ToString() => "waiting for turn of crank";
}
