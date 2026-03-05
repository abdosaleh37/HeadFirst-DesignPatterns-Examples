namespace Ch7_B_TheFacadePattern.Components
{
    public class Projector
    {
        private readonly StreamingPlayer _player;

        public Projector(StreamingPlayer player) => _player = player;

        public void On() => Console.WriteLine("Top-O-Line Projector on");

        public void Off() => Console.WriteLine("Top-O-Line Projector off");

        public void TvMode() => Console.WriteLine("Top-O-Line Projector in TV mode (4x3 aspect ratio)");

        public void WideScreenMode() => Console.WriteLine("Top-O-Line Projector in widescreen mode (16x9 aspect ratio)");

        public override string ToString() => "Top-O-Line Projector";
    }
}
