using Ch06_TheCommandPattern.Devices;
using Ch06_TheCommandPattern.Interfaces;

namespace Ch06_TheCommandPattern.Commands
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
