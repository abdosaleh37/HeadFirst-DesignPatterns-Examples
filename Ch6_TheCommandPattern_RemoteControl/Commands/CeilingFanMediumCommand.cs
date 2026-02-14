using Ch6_TheCommandPattern_RemoteControl.Devices;

namespace Ch6_TheCommandPattern_RemoteControl.Commands
{
    public class CeilingFanMediumCommand : CeilingFanCommandBase
    {
        public CeilingFanMediumCommand(CeilingFan ceilingFan) : base(ceilingFan) { }

        public override void Execute()
        {
            previousSpeed = _ceilingFan.Speed;
            _ceilingFan.Medium();
        }
    }
}
