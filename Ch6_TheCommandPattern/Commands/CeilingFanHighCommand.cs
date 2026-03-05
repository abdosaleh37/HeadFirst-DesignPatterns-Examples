using Ch6_TheCommandPattern.Devices;

namespace Ch6_TheCommandPattern.Commands
{
    public class CeilingFanHighCommand : CeilingFanCommandBase
    {
        public CeilingFanHighCommand(CeilingFan ceilingFan) : base(ceilingFan) { }

        public override void Execute()
        {
            previousSpeed = _ceilingFan.Speed;
            _ceilingFan.High();
        }
    }
}
