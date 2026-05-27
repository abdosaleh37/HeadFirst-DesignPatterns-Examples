using Ch06_TheCommandPattern.Commands;
using Ch06_TheCommandPattern.Interfaces;

namespace Ch06_TheCommandPattern.RemoteControls
{
    public class SimpleRemoteControl
    {
        public ICommand Slot { get; set; } = new NoCommand();

        public SimpleRemoteControl() { }

        public void ButtonWasPressed() => Slot.Execute();
    }
}
