using Ch6_TheCommandPattern.Commands;
using Ch6_TheCommandPattern.Interfaces;
using System.Text;

namespace Ch6_TheCommandPattern.RemoteControls
{
    public class RemoteControl
    {
        public int SlotCount { get; }
        public List<ICommand> OnCommands { get; } 
        public List<ICommand> OffCommands { get; }

        public RemoteControl(int slotCount)
        {
            SlotCount = slotCount;

            OnCommands = new List<ICommand>();
            OffCommands = new List<ICommand>();

            for (int i = 0; i < slotCount; i++)
            {
                OnCommands.Add(new NoCommand());
                OffCommands.Add(new NoCommand());
            }
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
        }

        public void OffButtonWasPushed(int slot)
        {
            if (slot < 0 || slot >= SlotCount)
            {
                Console.WriteLine("Invalid slot number.");
                return;
            }

            OffCommands[slot].Execute();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("\n------ Standard Remote Control ------");

            for (int i = 0; i < SlotCount; i++)
            {
                sb.AppendLine($"[slot {i}] {OnCommands[i].GetType().Name,-25}" +
                    $"    {OffCommands[i].GetType().Name}");
            }

            return sb.ToString();
        }
    }
}
