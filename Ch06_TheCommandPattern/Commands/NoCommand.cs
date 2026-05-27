using Ch06_TheCommandPattern.Interfaces;

namespace Ch06_TheCommandPattern.Commands
{
    public class NoCommand : ICommand
    {
        public void Execute() { }

        public void Undo() { }
    }
}
