using Ch06_TheCommandPattern.Devices;
using Ch06_TheCommandPattern.Interfaces;

namespace Ch06_TheCommandPattern.Commands
{
    public class LightOnCommand : ICommand
    {
        private readonly Light _light;

        public LightOnCommand(Light light) => _light = light;

        public void Execute() => _light.On();

        public void Undo() => _light.Off();
    }
}
