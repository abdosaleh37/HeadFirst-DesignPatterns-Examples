namespace Ch14_Appendix.Bridge;

public static class BridgeDemo
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("--- Bridge Pattern ---");

        IDevice tv = new Television();
        var remote = new BasicRemote(tv);

        remote.TogglePower();
        remote.VolumeUp();
        remote.VolumeUp();
        remote.TogglePower();
    }
}
