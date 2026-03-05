namespace Ch5_TheSingletonPattern.Boilers
{
    public class ChocolateBoilerNotThreadSafe
    {
        private bool isEmpty;
        private bool isBoiled;

        private static ChocolateBoilerNotThreadSafe? uniqueInstance;

        private ChocolateBoilerNotThreadSafe()
        {
            isEmpty = true;
            isBoiled = false;
            Console.WriteLine($"[NotThreadSafe] Creating ChocolateBoiler instance on Thread {Environment.CurrentManagedThreadId}");
            Thread.Sleep(100); // Simulate some work - makes the threading problem more visible
        }

        public static ChocolateBoilerNotThreadSafe GetInstance()
        {
            if (uniqueInstance == null)
            {
                // PROBLEM: Two threads could both check this condition before either creates the instance
                Console.WriteLine($"[NotThreadSafe] Thread {Environment.CurrentManagedThreadId} sees null instance");
                uniqueInstance = new ChocolateBoilerNotThreadSafe();
            }
            return uniqueInstance;
        }

        public void Fill()
        {
            if (IsEmpty())
            {
                isEmpty = false;
                isBoiled = false;
                Console.WriteLine($"[NotThreadSafe] Filling the boiler with milk/chocolate mixture (Thread {Environment.CurrentManagedThreadId})");
            }
        }

        public void Drain()
        {
            if (!IsEmpty() && IsBoiled())
            {
                Console.WriteLine($"[NotThreadSafe] Draining the boiled milk and chocolate (Thread {Environment.CurrentManagedThreadId})");
                isEmpty = true;
            }
        }

        public void Boil()
        {
            if (!IsEmpty() && !IsBoiled())
            {
                Console.WriteLine($"[NotThreadSafe] Bringing the contents to a boil (Thread {Environment.CurrentManagedThreadId})");
                isBoiled = true;
            }
        }

        public bool IsEmpty() => isEmpty;
        public bool IsBoiled() => isBoiled;
    }
}
