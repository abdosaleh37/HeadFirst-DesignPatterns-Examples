namespace Ch14_Appendix.Builder;

public sealed class ComputerBuilder
{
    private string _cpu = "Unknown CPU";
    private int _ramGb;
    private string _storage = "Unknown storage";

    public ComputerBuilder WithCpu(string cpu)
    {
        _cpu = cpu;
        return this;
    }

    public ComputerBuilder WithRamGb(int ramGb)
    {
        _ramGb = ramGb;
        return this;
    }

    public ComputerBuilder WithStorage(string storage)
    {
        _storage = storage;
        return this;
    }

    public Computer Build()
    {
        return new Computer
        {
            Cpu = _cpu,
            RamGb = _ramGb,
            Storage = _storage
        };
    }
}
