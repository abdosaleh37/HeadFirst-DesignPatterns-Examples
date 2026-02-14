namespace Ch6_TheCommandPattern_RemoteControl.Devices
{
    public class CeilingFan
    {
        public CeilingFanSpeed Speed { get; private set; }
        private readonly string _location;

        public CeilingFan(string location) => _location = location;

        public void High()
        {
            Speed = CeilingFanSpeed.High;
            Console.WriteLine($"{_location} ceiling fan is on HIGH");
        }

        public void Medium()
        {
            Speed = CeilingFanSpeed.Medium;
            Console.WriteLine($"{_location} ceiling fan is on MEDIUM");
        }

        public void Low()
        {
            Speed = CeilingFanSpeed.Low;
            Console.WriteLine($"{_location} ceiling fan is on LOW");
        }

        public void Off()
        {
            Speed = CeilingFanSpeed.Off;
            Console.WriteLine($"{_location} ceiling fan is OFF");
        }
    }

    public enum CeilingFanSpeed
    {
        Off = 0,
        Low = 1,
        Medium = 2,
        High = 3
    }
}
