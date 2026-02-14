using Ch6_TheCommandPattern_RemoteControl.Devices;
using Ch6_TheCommandPattern_RemoteControl.Interfaces;

namespace Ch6_TheCommandPattern_RemoteControl.Commands
{
    public class StereoOffCommand : ICommand
    {
        private readonly Stereo _stereo;

        public StereoOffCommand(Stereo stereo) => _stereo = stereo;

        public void Execute() => _stereo.Off();

        public void Undo()
        {
            _stereo.On();
            _stereo.SetCD();
            _stereo.SetVolume(11);
        }
    }
}
