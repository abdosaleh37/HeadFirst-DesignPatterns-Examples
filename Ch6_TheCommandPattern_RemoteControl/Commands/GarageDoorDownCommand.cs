using Ch6_TheCommandPattern_RemoteControl.Devices;
using Ch6_TheCommandPattern_RemoteControl.Interfaces;

namespace Ch6_TheCommandPattern_RemoteControl.Commands
{
    public class GarageDoorDownCommand : ICommand
    {
        private readonly GarageDoor _garage;

        public GarageDoorDownCommand(GarageDoor garage) => _garage = garage;

        public void Execute() => _garage.Down();

        public void Undo() => _garage.Up();
    }
}
