using Ch6_TheCommandPattern_RemoteControl.Commands;
using Ch6_TheCommandPattern_RemoteControl.Interfaces;
using System.Text;

namespace Ch6_TheCommandPattern_RemoteControl.RemoteControls
{
    public class RemoteControlWithMultipleUndos
    {
        public int SlotCount { get; }
        public List<ICommand> OnCommands { get; }
        public List<ICommand> OffCommands { get; }
        public Stack<ICommand> UndoCommands { get; }

        public RemoteControlWithMultipleUndos(int slotCount)
        {
            SlotCount = slotCount;

            OnCommands = new List<ICommand>();
            OffCommands = new List<ICommand>();

            for (int i = 0; i < slotCount; i++)
            {
                OnCommands.Add(new NoCommand());
                OffCommands.Add(new NoCommand());
            }

            UndoCommands = new Stack<ICommand>();
        }

        public void SetCommand(int slot, ICommand onCommand, ICommand offCommand)
        {
            if (slot < 0 || slot >= SlotCount)
            {
                Console.WriteLine("Invalid slot number.");
                return;
            }

            OnCommands[slot] = onCommand;
            OffCommands[slot] = offCommand;
        }

        public void OnButtonWasPushed(int slot)
        {
            if (slot < 0 || slot >= SlotCount)
            {
                Console.WriteLine("Invalid slot number.");
                return;
            }

            OnCommands[slot].Execute();
            UndoCommands.Push(OnCommands[slot]);
        }

        public void OffButtonWasPushed(int slot)
        {
            if (slot < 0 || slot >= SlotCount)
            {
                Console.WriteLine("Invalid slot number.");
                return;
            }

            OffCommands[slot].Execute();
            UndoCommands.Push(OffCommands[slot]);
        }

        public void UndoButtonWasPushed()
        {
            ICommand command = new NoCommand();
            
            if (UndoCommands.Count > 0)
            {
                command = UndoCommands.Pop();
            }

            command.Undo();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("\n------ Remote Control with Multiple Undos ------");

            for (int i = 0; i < SlotCount; i++)
            {
                sb.AppendLine($"[slot {i}] {OnCommands[i].GetType().Name,-25}" +
                    $"    {OffCommands[i].GetType().Name}");
            }

            sb.AppendLine($"[undo] {UndoCommands.Count} command(s) in history");

            return sb.ToString();
        }
    }
}
