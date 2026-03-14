using Ch10_TheStatePattern.Interfaces;
using Ch10_TheStatePattern.Models;

namespace Ch10_TheStatePattern.States;

public sealed class SoldOutState : IGumballState
{
    public SoldOutState() { }

    public void InsertQuarter() 
        => Console.WriteLine("You cannot insert a quarter, the machine is sold out.");

    public void EjectQuarter() 
        => Console.WriteLine("You cannot eject, you have not inserted a quarter yet.");

    public void TurnCrank() 
        => Console.WriteLine("You turned, but there are no gumballs.");

    public void Dispense() 
        => Console.WriteLine("No gumball dispensed.");

    public override string ToString() => "sold out";
}
