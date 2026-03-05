namespace Ch6_TheCommandPattern.Devices
{
    public class GarageDoor
    {
        private readonly string _location;

        public GarageDoor(string location) => _location = location;

        public void Up() => Console.WriteLine($"{_location} garage door is OPEN");

        public void Down() => Console.WriteLine($"{_location} garage door is CLOSED");

        public void Stop() => Console.WriteLine($"{_location} garage door is STOPPED");

        public void LightOn() => Console.WriteLine($"{_location} garage light is ON");

        public void LightOff() => Console.WriteLine($"{_location} garage light is OFF");
    }
}
