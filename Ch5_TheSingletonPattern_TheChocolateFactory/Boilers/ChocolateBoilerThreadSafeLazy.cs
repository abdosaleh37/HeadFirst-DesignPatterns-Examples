namespace Ch5_TheSingletonPattern_TheChocolateFactory.Boilers
{
    public class ChocolateBoilerThreadSafeLazy
    {
        private bool isEmpty;
        private bool isBoiled;

        private static ChocolateBoilerThreadSafeLazy? uniqueInstance;

        private static readonly object lockObject = new object();

        private ChocolateBoilerThreadSafeLazy()
        {
            isEmpty = true;
            isBoiled = false;
            Console.WriteLine($"[ThreadSafeLazy] Creating ChocolateBoiler instance on Thread {Environment.CurrentManagedThreadId}");
            Thread.Sleep(100); // Simulate some work
        }

        public static ChocolateBoilerThreadSafeLazy GetInstance()
        {
            if (uniqueInstance == null) // First check (no locking)
            {
                lock (lockObject) // Only lock if instance is null
                {
                    if (uniqueInstance == null) // Double-check inside lock
                    {
                        Console.WriteLine($"[ThreadSafeLazy] Thread {Environment.CurrentManagedThreadId} creating instance inside lock");
                        uniqueInstance = new ChocolateBoilerThreadSafeLazy();
                    }
                    else
                    {
                        Console.WriteLine($"[ThreadSafeLazy] Thread {Environment.CurrentManagedThreadId} waited on lock, instance already created");
                    }
                }
            }
            return uniqueInstance;
        }

        public void Fill()
        {
            if (IsEmpty())
            {
                isEmpty = false;
                isBoiled = false;
                Console.WriteLine($"[ThreadSafeLazy] Filling the boiler with milk/chocolate mixture (Thread {Environment.CurrentManagedThreadId})");
            }
        }

        public void Drain()
        {
            if (!IsEmpty() && IsBoiled())
            {
                Console.WriteLine($"[ThreadSafeLazy] Draining the boiled milk and chocolate (Thread {Environment.CurrentManagedThreadId})");
                isEmpty = true;
            }
        }

        public void Boil()
        {
            if (!IsEmpty() && !IsBoiled())
            {
                Console.WriteLine($"[ThreadSafeLazy] Bringing the contents to a boil (Thread {Environment.CurrentManagedThreadId})");
                isBoiled = true;
            }
        }

        public bool IsEmpty() => isEmpty;
        public bool IsBoiled() => isBoiled;
    }
}
