using Ch06_TheCommandPattern.Devices;

namespace Ch06_TheCommandPattern.Commands
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
