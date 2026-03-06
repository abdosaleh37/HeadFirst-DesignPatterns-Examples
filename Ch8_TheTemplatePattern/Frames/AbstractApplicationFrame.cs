namespace Ch8_TheTemplatePattern.Frames
{
    public abstract class AbstractApplicationFrame
    {
        public void Run()
        {
            Initialize();
            while (!IsDone())
            {
                Handle();
            }
            Cleanup();
        }

        protected virtual void Initialize() 
            => Console.WriteLine("  Default initialize (no-op)");

        protected abstract void Handle();

        protected abstract bool IsDone();

        protected virtual void Cleanup() 
            => Console.WriteLine("  Default cleanup (no-op)");
    }
}
