namespace Ch6_TheCommandPattern_RemoteControl.Interfaces
{
    public interface ICommand
    {
        public void Execute();

        public void Undo();
    }
}
