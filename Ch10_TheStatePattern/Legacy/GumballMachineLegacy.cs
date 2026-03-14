namespace Ch10_TheStatePattern.Legacy;

public sealed class GumballMachineLegacy
{
    private const int SoldOut = 0;
    private const int NoQuarter = 1;
    private const int HasQuarter = 2;
    private const int Sold = 3;

    private int _state;
    private int _count;

    public GumballMachineLegacy(int numberGumballs)
    {
        _count = numberGumballs;
        _state = numberGumballs > 0 ? NoQuarter : SoldOut;
    }

    public void InsertQuarter()
    {
        if (_state == HasQuarter)
        {
            Console.WriteLine("You cannot insert another quarter.");
        }
        else if (_state == NoQuarter)
        {
            _state = HasQuarter;
            Console.WriteLine("You inserted a quarter.");
        }
        else if (_state == SoldOut)
        {
            Console.WriteLine("You cannot insert a quarter, the machine is sold out.");
        }
        else if (_state == Sold)
        {
            Console.WriteLine("Please wait, we're already giving you a gumball.");
        }
    }

    public void EjectQuarter()
    {
        if (_state == HasQuarter)
        {
            Console.WriteLine("Quarter returned.");
            _state = NoQuarter;
        }
        else if (_state == NoQuarter)
        {
            Console.WriteLine("You have not inserted a quarter.");
        }
        else if (_state == Sold)
        {
            Console.WriteLine("Sorry, you already turned the crank.");
        }
        else if (_state == SoldOut)
        {
            Console.WriteLine("You cannot eject, you have not inserted a quarter yet.");
        }
    }

    public void TurnCrank()
    {
        if (_state == Sold)
        {
            Console.WriteLine("Turning twice does not get you another gumball.");
        }
        else if (_state == NoQuarter)
        {
            Console.WriteLine("You turned, but there is no quarter.");
        }
        else if (_state == SoldOut)
        {
            Console.WriteLine("You turned, but there are no gumballs.");
        }
        else if (_state == HasQuarter)
        {
            Console.WriteLine("You turned...");
            _state = Sold;
            Dispense();
        }
    }

    private void Dispense()
    {
        if (_state == Sold)
        {
            Console.WriteLine("A gumball comes rolling out the slot.");
            _count--;

            if (_count == 0)
            {
                Console.WriteLine("Oops, out of gumballs.");
                _state = SoldOut;
            }
            else
            {
                _state = NoQuarter;
            }
        }
        else if (_state == NoQuarter)
        {
            Console.WriteLine("You need to pay first.");
        }
        else if (_state == SoldOut)
        {
            Console.WriteLine("No gumball dispensed.");
        }
        else if (_state == HasQuarter)
        {
            Console.WriteLine("No gumball dispensed.");
        }
    }

    public override string ToString()
    {
        string stateLabel = _state switch
        {
            SoldOut => "sold out",
            NoQuarter => "waiting for quarter",
            HasQuarter => "waiting for turn of crank",
            Sold => "delivering a gumball",
            _ => "unknown"
        };

        return
            $"Mighty Gumball, Inc. (Legacy)\n" +
            "C#-enabled Standing Gumball Model #2026\n" +
            $"Inventory: {_count} gumball{(_count == 1 ? string.Empty : "s")}\n" +
            $"Machine is {stateLabel}.\n";
    }
}
