using Ch6_TheCommandPattern.Commands;
using Ch6_TheCommandPattern.Interfaces;

namespace Ch6_TheCommandPattern.RemoteControls
{
    public class SimpleRemoteControl
    {
        public ICommand Slot { get; set; } = new NoCommand();

        public SimpleRemoteControl() { }

        public void ButtonWasPressed() => Slot.Execute();
    }
}
