using Ch10_TheStatePattern.Interfaces;
using Ch10_TheStatePattern.States;

namespace Ch10_TheStatePattern.Models;

public sealed class GumballMachine
{
    public IGumballState SoldOutState { get; }
    public IGumballState NoQuarterState { get; }
    public IGumballState HasQuarterState { get; }
    public IGumballState SoldState { get; }
    public IGumballState WinnerState { get; }

    public IGumballState State { get; private set; }

    public int Count { get; private set; }

    public GumballMachine(int numberGumballs)
    {
        SoldOutState = new SoldOutState();
        NoQuarterState = new NoQuarterState(this);
        HasQuarterState = new HasQuarterState(this);
        SoldState = new SoldState(this);
        WinnerState = new WinnerState(this);

        Count = numberGumballs;
        State = numberGumballs > 0 ? NoQuarterState : SoldOutState;
    }

    public void InsertQuarter() => State.InsertQuarter();

    public void EjectQuarter() => State.EjectQuarter();

    public void TurnCrank()
    {
        State.TurnCrank();
        State.Dispense();
    }

    public void SetState(IGumballState state) => State = state;

    public void ReleaseBall()
    {
        Console.WriteLine("A gumball comes rolling out the slot.");
        if (Count > 0)
        {
            Count--;
        }
    }

    public void Refill(int gumballs)
    {
        Count += gumballs;
        Console.WriteLine($"The gumball machine was refilled. New count is: {Count}.");
        State = NoQuarterState;
    }

    public override string ToString()
    {
        return
            "Mighty Gumball, Inc.\n" +
            "C#-enabled Standing Gumball Model #2026\n" +
            $"Inventory: {Count} gumball{(Count == 1 ? string.Empty : "s")}\n" +
            $"Machine is {State}.\n";
    }
}
