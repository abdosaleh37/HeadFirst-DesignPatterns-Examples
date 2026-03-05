using Ch6_TheCommandPattern.Interfaces;

namespace Ch6_TheCommandPattern.Commands
{
    public class NoCommand : ICommand
    {
        public void Execute() { }

        public void Undo() { }
    }
}
