namespace Ch8_TheTemplateMethodPattern.Frames
{
    public class CountdownApp : AbstractApplicationFrame
    {
        private int _count = 5;

        protected override void Initialize() 
            => Console.WriteLine("  CountdownApp: Initializing — starting countdown from 5");

        protected override void Handle() 
            => Console.WriteLine($"  CountdownApp: Tick — {_count--}");

        protected override bool IsDone() => _count < 0;

        protected override void Cleanup() 
            => Console.WriteLine("  CountdownApp: Cleanup — countdown complete, BLAST OFF!");
    }
}
