namespace Ch7_II_TheFacadePattern.Components
{
    public class Tuner
    {
        private readonly Amplifier _amplifier;

        public Tuner(Amplifier amplifier) => _amplifier = amplifier;

        public void On() => Console.WriteLine("AM/FM Tuner on");

        public void Off() => Console.WriteLine("AM/FM Tuner off");

        public void SetAM() => Console.WriteLine("AM/FM Tuner setting AM mode");

        public void SetFM() => Console.WriteLine("AM/FM Tuner setting FM mode");

        public void SetFrequency(double frequency) => Console.WriteLine($"AM/FM Tuner setting frequency to {frequency}");

        public override string ToString() => "AM/FM Tuner";
    }
}
