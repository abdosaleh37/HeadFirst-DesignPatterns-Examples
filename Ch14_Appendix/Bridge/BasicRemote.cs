namespace Ch14_Appendix.Bridge;

public class BasicRemote
{
    private readonly IDevice _device;

    public BasicRemote(IDevice device)
    {
        _device = device;
    }

    public void TogglePower()
    {
        if (_device.IsEnabled)
        {
            _device.Disable();
            return;
        }

        _device.Enable();
    }

    public void VolumeUp() => _device.SetVolume(_device.Volume + 5);
}
