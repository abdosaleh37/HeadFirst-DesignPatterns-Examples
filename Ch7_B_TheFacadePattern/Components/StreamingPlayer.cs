namespace Ch7_B_TheFacadePattern.Components
{
    public class StreamingPlayer
    {
        private readonly Amplifier _amplifier;
        private string _movie = string.Empty;
        private int _currentChapter;

        public StreamingPlayer(Amplifier amplifier) => _amplifier = amplifier;

        public void On() => Console.WriteLine("Top-O-Line Streaming Player on");

        public void Off() => Console.WriteLine("Top-O-Line Streaming Player off");

        public void Pause() => Console.WriteLine($"Top-O-Line Streaming Player paused \"{_movie}\" at chapter {_currentChapter}");

        public void Play(string movie)
        {
            _movie = movie;
            _currentChapter = 0;
            Console.WriteLine($"Top-O-Line Streaming Player playing \"{_movie}\"");
        }

        public void Stop()
        {
            _currentChapter = 0;
            Console.WriteLine($"Top-O-Line Streaming Player stopped \"{_movie}\"");
        }

        public void SetSurroundAudio() => Console.WriteLine("Top-O-Line Streaming Player surround audio on");

        public void SetTwoChannelAudio() => Console.WriteLine("Top-O-Line Streaming Player two channel audio on");

        public override string ToString() => "Top-O-Line Streaming Player";
    }
}
