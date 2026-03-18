namespace Ch11_TheProxyPattern.Models;

public sealed class GumballMachineService
{
    private readonly object _sync = new();

    public string Location { get; }
    public int Count { get; private set; }
    public string State => Count > 0 ? "waiting for quarter" : "sold out";

    public GumballMachineService(string location, int count)
    {
        Location = location;
        Count = count;
    }

    public GumballMachineSnapshot GetSnapshot()
    {
        lock (_sync)
        {
            return new GumballMachineSnapshot(Location, Count, State);
        }
    }

    public void InsertQuarterAndTurnCrank()
    {
        lock (_sync)
        {
            if (Count > 0)
            {
                Count--;
            }
        }
    }
}
