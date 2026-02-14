using Ch6_TheCommandPattern_RemoteControl.Devices;
using Ch6_TheCommandPattern_RemoteControl.Interfaces;

namespace Ch6_TheCommandPattern_RemoteControl.Commands
{
    public class LightOnCommand : ICommand
    {
        private readonly Light _light;

        public LightOnCommand(Light light) => _light = light;

        public void Execute() => _light.On();

        public void Undo() => _light.Off();
    }
}
