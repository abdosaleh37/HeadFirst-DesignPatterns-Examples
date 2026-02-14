using Ch6_TheCommandPattern_RemoteControl.Devices;
using Ch6_TheCommandPattern_RemoteControl.Interfaces;

namespace Ch6_TheCommandPattern_RemoteControl.Commands
{
    public abstract class CeilingFanCommandBase : ICommand
    {
        protected readonly CeilingFan _ceilingFan;
        protected CeilingFanSpeed previousSpeed;

        protected CeilingFanCommandBase(CeilingFan ceilingFan) => _ceilingFan = ceilingFan;

        public abstract void Execute();

        public void Undo()
        {
            RestoreSpeed(previousSpeed);
        }

        protected void RestoreSpeed(CeilingFanSpeed speed)
        {
            switch (speed)
            {
                case CeilingFanSpeed.Low:
                    _ceilingFan.Low();
                    break;

                case CeilingFanSpeed.Medium:
                    _ceilingFan.Medium();
                    break;

                case CeilingFanSpeed.High:
                    _ceilingFan.High();
                    break;

                default:
                    _ceilingFan.Off();
                    break;
            }
        }
    }
}
