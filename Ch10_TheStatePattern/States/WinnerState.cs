using Ch10_TheStatePattern.Interfaces;
using Ch10_TheStatePattern.Models;

namespace Ch10_TheStatePattern.States;

public sealed class WinnerState : IGumballState
{
    private readonly GumballMachine _gumballMachine;

    public WinnerState(GumballMachine gumballMachine) 
        => _gumballMachine = gumballMachine;

    public void InsertQuarter() 
        => Console.WriteLine("Please wait, we're already giving you a gumball.");

    public void EjectQuarter() 
        => Console.WriteLine("Sorry, you already turned the crank.");

    public void TurnCrank() 
        => Console.WriteLine("Turning twice does not get you another gumball.");

    public void Dispense()
    {
        Console.WriteLine("YOU'RE A WINNER! You got two gumballs for your quarter.");
        _gumballMachine.ReleaseBall();

        if (_gumballMachine.Count == 0)
        {
            _gumballMachine.SetState(_gumballMachine.SoldOutState);
            return;
        }

        _gumballMachine.ReleaseBall();
        if (_gumballMachine.Count > 0)
        {
            _gumballMachine.SetState(_gumballMachine.NoQuarterState);
        }
        else
        {
            Console.WriteLine("Oops, out of gumballs.");
            _gumballMachine.SetState(_gumballMachine.SoldOutState);
        }
    }

    public override string ToString() 
        => "dispensing two gumballs for your quarter, because YOU'RE A WINNER!";
}
