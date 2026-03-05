using Ch6_TheCommandPattern.Devices;
using Ch6_TheCommandPattern.Interfaces;

namespace Ch6_TheCommandPattern.Commands
{
    public class GarageDoorUpCommand : ICommand
    {
        private readonly GarageDoor _garage;

        public GarageDoorUpCommand(GarageDoor garage) => _garage = garage;

        public void Execute() => _garage.Up();

        public void Undo() => _garage.Down();
    }
}
