using Ch6_TheCommandPattern.Devices;

namespace Ch6_TheCommandPattern.Commands
{
    public class CeilingFanLowCommand : CeilingFanCommandBase
    {
        public CeilingFanLowCommand(CeilingFan ceilingFan) : base(ceilingFan) { }

        public override void Execute()
        {
            previousSpeed = _ceilingFan.Speed;
            _ceilingFan.Low();
        }
    }
}
