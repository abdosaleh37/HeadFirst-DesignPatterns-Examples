namespace Ch7_B_TheFacadePattern.Components
{
    public class TheaterLights
    {
        public void On() => Console.WriteLine("Theater Ceiling Lights on");

        public void Off() => Console.WriteLine("Theater Ceiling Lights off");

        public void Dim(int level) => Console.WriteLine($"Theater Ceiling Lights dimming to {level}%");

        public override string ToString() => "Theater Ceiling Lights";
    }
}
