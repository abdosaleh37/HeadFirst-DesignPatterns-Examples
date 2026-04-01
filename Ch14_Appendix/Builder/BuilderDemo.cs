namespace Ch14_Appendix.Builder;

public static class BuilderDemo
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("--- Builder Pattern ---");

        var gamingPc = new ComputerBuilder()
            .WithCpu("Ryzen 9")
            .WithRamGb(32)
            .WithStorage("2TB NVMe")
            .Build();

        Console.WriteLine($"Built machine: {gamingPc.Cpu}, {gamingPc.RamGb}GB RAM, {gamingPc.Storage}.");
    }
}
