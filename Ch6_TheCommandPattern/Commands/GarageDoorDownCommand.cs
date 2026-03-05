using Ch6_TheCommandPattern.Devices;
using Ch6_TheCommandPattern.Interfaces;

namespace Ch6_TheCommandPattern.Commands
{
    public class GarageDoorDownCommand : ICommand
    {
        private readonly GarageDoor _garage;

        public GarageDoorDownCommand(GarageDoor garage) => _garage = garage;

        public void Execute() => _garage.Down();

        public void Undo() => _garage.Up();
    }
}
