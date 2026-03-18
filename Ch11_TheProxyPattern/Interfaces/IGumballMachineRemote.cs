namespace Ch11_TheProxyPattern.Interfaces;

public interface IGumballMachineRemote
{
    string Location { get; }
    int Count { get; }
    string State { get; }
}
