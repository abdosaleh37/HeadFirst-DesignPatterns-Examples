namespace Ch5_TheSingletonPattern_TheChocolateFactory.Boilers
{
    public class ChocolateBoilerLazyT
    {
        private bool isEmpty;
        private bool isBoiled;

        private static readonly Lazy<ChocolateBoilerLazyT> lazy =
            new Lazy<ChocolateBoilerLazyT>(() => new ChocolateBoilerLazyT());

        public static ChocolateBoilerLazyT Instance => lazy.Value;

        private ChocolateBoilerLazyT()
        {
            isEmpty = true;
            isBoiled = false;
            Console.WriteLine($"[LazyT] Creating ChocolateBoiler instance on Thread {Environment.CurrentManagedThreadId}");
            Thread.Sleep(100); // Simulate some work
        }

        public void Fill()
        {
            if (IsEmpty())
            {
                isEmpty = false;
                isBoiled = false;
                Console.WriteLine($"[LazyT] Filling the boiler with milk/chocolate mixture (Thread {Environment.CurrentManagedThreadId})");
            }
        }

        public void Drain()
        {
            if (!IsEmpty() && IsBoiled())
            {
                Console.WriteLine($"[LazyT] Draining the boiled milk and chocolate (Thread {Environment.CurrentManagedThreadId})");
                isEmpty = true;
            }
        }

        public void Boil()
        {
            if (!IsEmpty() && !IsBoiled())
            {
                Console.WriteLine($"[LazyT] Bringing the contents to a boil (Thread {Environment.CurrentManagedThreadId})");
                isBoiled = true;
            }
        }

        public bool IsEmpty() => isEmpty;
        public bool IsBoiled() => isBoiled;
    }
}
