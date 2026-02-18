namespace Ch7_II_TheFacadePattern.Components
{
    public class Amplifier
    {
        private Tuner? _tuner;
        private StreamingPlayer? _player;

        public void On() => Console.WriteLine("Top-O-Line Amplifier on");

        public void Off() => Console.WriteLine("Top-O-Line Amplifier off");

        public void SetStreamingPlayer(StreamingPlayer player)
        {
            _player = player;
            Console.WriteLine($"Top-O-Line Amplifier setting Streaming player to {player}");
        }

        public void SetStereoSound() => Console.WriteLine("Top-O-Line Amplifier stereo mode on");

        public void SetSurroundSound() => Console.WriteLine("Top-O-Line Amplifier surround sound on (5 speakers, 1 subwoofer)");

        public void SetTuner(Tuner tuner)
        {
            _tuner = tuner;
            Console.WriteLine($"Top-O-Line Amplifier setting tuner to {tuner}");
        }

        public void SetVolume(int level) => Console.WriteLine($"Top-O-Line Amplifier setting volume to {level}");

        public override string ToString() => "Top-O-Line Amplifier";
    }
}
