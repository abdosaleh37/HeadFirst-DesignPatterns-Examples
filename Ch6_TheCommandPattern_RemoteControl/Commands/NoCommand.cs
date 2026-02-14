using Ch6_TheCommandPattern_RemoteControl.Interfaces;

namespace Ch6_TheCommandPattern_RemoteControl.Commands
{
    public class NoCommand : ICommand
    {
        public void Execute() { }

        public void Undo() { }
    }
}
