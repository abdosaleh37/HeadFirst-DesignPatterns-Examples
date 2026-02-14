using Ch6_TheCommandPattern_RemoteControl.Commands;
using Ch6_TheCommandPattern_RemoteControl.Interfaces;

namespace Ch6_TheCommandPattern_RemoteControl.RemoteControls
{
    public class SimpleRemoteControl
    {
        public ICommand Slot { get; set; } = new NoCommand();

        public SimpleRemoteControl() { }

        public void ButtonWasPressed() => Slot.Execute();
    }
}
