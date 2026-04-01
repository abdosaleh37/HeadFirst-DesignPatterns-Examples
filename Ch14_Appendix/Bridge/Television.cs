namespace Ch14_Appendix.Bridge;

public sealed class Television : IDevice
{
    public bool IsEnabled { get; private set; }
    public int Volume { get; private set; } = 10;

    public void Enable()
    {
        IsEnabled = true;
        Console.WriteLine("TV turned on.");
    }

    public void Disable()
    {
        IsEnabled = false;
        Console.WriteLine("TV turned off.");
    }

    public void SetVolume(int volume)
    {
        Volume = Math.Clamp(volume, 0, 100);
        Console.WriteLine($"TV volume is now {Volume}.");
    }
}
