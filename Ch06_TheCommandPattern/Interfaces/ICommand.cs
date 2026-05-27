namespace Ch06_TheCommandPattern.Interfaces
{
    public interface ICommand
    {
        public void Execute();

        public void Undo();
    }
}
