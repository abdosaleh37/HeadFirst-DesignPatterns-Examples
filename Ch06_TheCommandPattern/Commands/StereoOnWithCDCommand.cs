using Ch06_TheCommandPattern.Devices;
using Ch06_TheCommandPattern.Interfaces;

namespace Ch06_TheCommandPattern.Commands
{
    public class StereoOnWithCDCommand : ICommand
    {
        private readonly Stereo _stereo;

        public StereoOnWithCDCommand(Stereo stereo) => _stereo = stereo;

        public void Execute()
        {
            _stereo.On();
            _stereo.SetCD();
            _stereo.SetVolume(11);
        }

        public void Undo() => _stereo.Off();
    }
}
