using Ch05_TheSingletonPattern.Boilers;

namespace Ch05_TheSingletonPattern
{
    internal class Program
    {
        private const int ThreadCount = 3;

        static void Main(string[] args)
        {
            PrintSection("Chapter 5 - Singleton Pattern");

            DemoEagerSingleton();

            Pause("Press any key to continue to threading demos...");

            RunThreadedDemo(
                "Threading: Not thread safe (expected to fail)",
                () => ChocolateBoilerNotThreadSafe.GetInstance(),
                expectSingleInstance: false);

            Pause("Press any key to continue to double-checked locking...");

            RunThreadedDemo(
                "Threading: Double-checked locking",
                () => ChocolateBoilerThreadSafeLazy.GetInstance(),
                expectSingleInstance: true);

            Pause("Press any key to continue to Lazy<T>...");

            RunThreadedDemo(
                "Threading: Lazy<T>",
                () => ChocolateBoilerLazyT.Instance,
                expectSingleInstance: true);

            Pause("Press any key to exit...");
        }

        private static void DemoEagerSingleton()
        {
            PrintSection("Eager singleton (ChocolateBoiler)");

            var boiler = ChocolateBoiler.Boiler;
            PrintState("Initial", boiler);

            Console.WriteLine("Fill");
            boiler.Fill();
            PrintState("After fill", boiler);

            Console.WriteLine("Boil");
            boiler.Boil();
            PrintState("After boil", boiler);

            Console.WriteLine("Drain");
            boiler.Drain();
            PrintState("After drain", boiler);

            var same = ReferenceEquals(boiler, ChocolateBoiler.Boiler);
            Console.WriteLine($"Same instance? {same}");
        }

        private static void RunThreadedDemo<T>(string title, Func<T> getInstance, bool expectSingleInstance)
            where T : class
        {
            PrintSection(title);

            var threads = new Thread[ThreadCount];
            var instances = new T?[ThreadCount];

            for (int i = 0; i < ThreadCount; i++)
            {
                int index = i;
                threads[i] = new Thread(() =>
                {
                    instances[index] = getInstance();
                    Console.WriteLine($"Thread {Environment.CurrentManagedThreadId} got {instances[index]!.GetHashCode()}");
                });
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            int uniqueInstances = instances.Where(i => i != null)
                .Select(i => i!.GetHashCode())
                .Distinct()
                .Count();

            Console.WriteLine($"Unique instances: {uniqueInstances}");
            if (expectSingleInstance && uniqueInstances != 1)
            {
                Console.WriteLine("Result: NOT SINGLETON (unexpected).");
            }
            else if (!expectSingleInstance && uniqueInstances == 1)
            {
                Console.WriteLine("Result: Looked safe this run, but it is not thread-safe.");
            }
            else if (expectSingleInstance)
            {
                Console.WriteLine("Result: Singleton preserved.");
            }
            else
            {
                Console.WriteLine("Result: Multiple instances detected.");
            }
        }

        private static void PrintState(string label, ChocolateBoiler boiler)
        {
            Console.WriteLine($"{label} state - Empty: {boiler.IsEmpty()}, Boiled: {boiler.IsBoiled()}");
        }

        private static void PrintSection(string title)
        {
            Console.WriteLine();
            Console.WriteLine(new string('-', 60));
            Console.WriteLine(title);
            Console.WriteLine(new string('-', 60));
        }

        private static void Pause(string message)
        {
            Console.WriteLine();
            Console.WriteLine(message);
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}
