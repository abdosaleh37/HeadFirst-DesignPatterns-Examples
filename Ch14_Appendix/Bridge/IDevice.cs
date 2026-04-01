namespace Ch14_Appendix.Bridge;

public interface IDevice
{
    bool IsEnabled { get; }
    int Volume { get; }
    void Enable();
    void Disable();
    void SetVolume(int volume);
}
