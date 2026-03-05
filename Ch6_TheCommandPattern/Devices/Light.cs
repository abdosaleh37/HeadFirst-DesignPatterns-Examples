namespace Ch6_TheCommandPattern.Devices
{
    public class Light
    {
        private readonly string _location;

        public Light(string location) => _location = location;

        public void On() => Console.WriteLine($"{_location} light is ON");

        public void Off() => Console.WriteLine($"{_location} light is OFF");
    }
}
