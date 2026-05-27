using Ch06_TheCommandPattern.Devices;

namespace Ch06_TheCommandPattern.Commands
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
