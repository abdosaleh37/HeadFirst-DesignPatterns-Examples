using Ch11_TheProxyPattern.Interfaces;

namespace Ch11_TheProxyPattern.Models;

public sealed class GumballMonitor(IGumballMachineRemote machine)
{
    private readonly IGumballMachineRemote _machine = machine;

    public string BuildReport()
    {
        return
            "Gumball Machine Report\n" +
            $"Location: {_machine.Location}\n" +
            $"Current inventory: {_machine.Count} gumballs\n" +
            $"Current state: {_machine.State}\n";
    }
}
