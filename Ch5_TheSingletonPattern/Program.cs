using Ch5_TheSingletonPattern.Boilers;

namespace Ch5_TheSingletonPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║       Chocolate Boiler Singleton Pattern Demonstration       ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝\n");

            // Part 1: Basic Singleton Usage
            BasicSingletonDemo();

            Console.WriteLine("\n" + new string('═', 62));
            Console.WriteLine("Press any key to see threading problems with Singleton...");
            Console.WriteLine(new string('═', 62));
            Console.ReadKey();
            Console.Clear();

            // Part 2: Threading Demonstrations
            ThreadingDemo();

            Console.WriteLine("\n" + new string('═', 62));
            Console.WriteLine("Demo completed! Press any key to exit...");
            Console.ReadKey();
        }

        static void BasicSingletonDemo()
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║     PART 1: Basic Singleton Usage (Eager Initialization)     ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝\n");

            // Get the singleton instance
            ChocolateBoiler boiler = ChocolateBoiler.Boiler;
            
            Console.WriteLine($"Initial state - Empty: {boiler.IsEmpty()}, Boiled: {boiler.IsBoiled()}\n");

            // Fill the boiler
            Console.WriteLine("Step 1: Fill the boiler");
            boiler.Fill();
            Console.WriteLine($"State - Empty: {boiler.IsEmpty()}, Boiled: {boiler.IsBoiled()}\n");

            // Boil the mixture
            Console.WriteLine("Step 2: Boil the mixture");
            boiler.Boil();
            Console.WriteLine($"State - Empty: {boiler.IsEmpty()}, Boiled: {boiler.IsBoiled()}\n");

            // Drain the boiler
            Console.WriteLine("Step 3: Drain the boiler");
            boiler.Drain();
            Console.WriteLine($"State - Empty: {boiler.IsEmpty()}, Boiled: {boiler.IsBoiled()}\n");

            // Verify it's the same instance
            Console.WriteLine("─────────────────────────────────────────────────────────────");
            Console.WriteLine("Verifying Singleton: Getting instance from another reference");
            Console.WriteLine("─────────────────────────────────────────────────────────────");
            ChocolateBoiler anotherBoiler = ChocolateBoiler.Boiler;
            Console.WriteLine($"Are both references the same instance? {ReferenceEquals(boiler, anotherBoiler)}");
            Console.WriteLine($"Another boiler state - Empty: {anotherBoiler.IsEmpty()}, Boiled: {anotherBoiler.IsBoiled()}\n");

            // Try to fill again to complete a second batch
            Console.WriteLine("─────────────────────────────────────────────────────────────");
            Console.WriteLine("                   Starting Second Batch                     ");
            Console.WriteLine("─────────────────────────────────────────────────────────────");
            anotherBoiler.Fill();
            anotherBoiler.Boil();
            anotherBoiler.Drain();
            Console.WriteLine();
        }

        static void ThreadingDemo()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║       PART 2: Multithreading Scenarios (From the Book!)       ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            // Demo 1: NOT Thread Safe
            TestNotThreadSafe();

            Console.WriteLine("\n" + new string('─', 62));
            Console.WriteLine("Press any key to see thread-safe with double-checked locking...");
            Console.ReadKey();
            Console.WriteLine();

            // Demo 2: Thread Safe with Double-Checked Locking
            TestThreadSafeLazy();

            Console.WriteLine("\n" + new string('─', 62));
            Console.WriteLine("Press any key to see Lazy<T> approach...");
            Console.ReadKey();
            Console.WriteLine();

            // Demo 3: Thread Safe with Lazy<T>
            TestLazyT();
        }

        static void TestNotThreadSafe()
        {
            Console.WriteLine("┌──────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│            Demo 1: NOT THREAD SAFE - The Problem!            │");
            Console.WriteLine("│   Multiple threads trying to get instance simultaneously...  │");
            Console.WriteLine("└──────────────────────────────────────────────────────────────┘\n");

            var threads = new Thread[5];
            var instances = new ChocolateBoilerNotThreadSafe?[5];

            for (int i = 0; i < 5; i++)
            {
                int index = i;
                threads[i] = new Thread(() =>
                {
                    instances[index] = ChocolateBoilerNotThreadSafe.GetInstance();
                    Console.WriteLine($"Thread {Environment.CurrentManagedThreadId} got instance: {instances[index]?.GetHashCode()}");
                });
            }

            // Start all threads at nearly the same time
            foreach (var thread in threads)
            {
                thread.Start();
            }

            // Wait for all threads to complete
            foreach (var thread in threads)
            {
                thread.Join();
            }

            // Check if all instances are the same
            Console.WriteLine("\n📊 Results:");
            var uniqueInstances = instances.Where(i => i != null).Select(i => i!.GetHashCode()).Distinct().Count();
            if (uniqueInstances > 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"❌ PROBLEM: Created {uniqueInstances} different instances! (Should be only 1)");
                Console.ResetColor();
                Console.WriteLine("This is the threading problem the book warns about!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"✓ Good: Only {uniqueInstances} instance created.");
                Console.ResetColor();
                Console.WriteLine("(Note: Sometimes you might get lucky and still get 1 instance)");
            }
        }

        static void TestThreadSafeLazy()
        {
            Console.WriteLine("┌──────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│       Demo 2: THREAD SAFE with Double-Checked Locking        │");
            Console.WriteLine("│             The classic solution from the book!              │");
            Console.WriteLine("└──────────────────────────────────────────────────────────────┘\n");

            var threads = new Thread[5];
            var instances = new ChocolateBoilerThreadSafeLazy?[5];

            for (int i = 0; i < 5; i++)
            {
                int index = i;
                threads[i] = new Thread(() =>
                {
                    instances[index] = ChocolateBoilerThreadSafeLazy.GetInstance();
                    Console.WriteLine($"Thread {Environment.CurrentManagedThreadId} got instance: {instances[index]?.GetHashCode()}");
                });
            }

            // Start all threads
            foreach (var thread in threads)
            {
                thread.Start();
            }

            // Wait for all threads
            foreach (var thread in threads)
            {
                thread.Join();
            }

            // Check results
            Console.WriteLine("\n📊 Results:");
            var uniqueInstances = instances.Where(i => i != null).Select(i => i!.GetHashCode()).Distinct().Count();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"✓ Success: Only {uniqueInstances} instance created!");
            Console.ResetColor();
            Console.WriteLine("Double-checked locking ensures thread safety!");
        }

        static void TestLazyT()
        {
            Console.WriteLine("┌──────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│               Demo 3: THREAD SAFE with Lazy<T>               │");
            Console.WriteLine("│        Modern C# approach - simplest and recommended!        │");
            Console.WriteLine("└──────────────────────────────────────────────────────────────┘\n");

            var threads = new Thread[5];
            var instances = new ChocolateBoilerLazyT?[5];

            for (int i = 0; i < 5; i++)
            {
                int index = i;
                threads[i] = new Thread(() =>
                {
                    instances[index] = ChocolateBoilerLazyT.Instance;
                    Console.WriteLine($"Thread {Environment.CurrentManagedThreadId} got instance: {instances[index]?.GetHashCode()}");
                });
            }

            // Start all threads
            foreach (var thread in threads)
            {
                thread.Start();
            }

            // Wait for all threads
            foreach (var thread in threads)
            {
                thread.Join();
            }

            // Check results
            Console.WriteLine("\n📊 Results:");
            var uniqueInstances = instances.Where(i => i != null).Select(i => i!.GetHashCode()).Distinct().Count();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"✓ Success: Only {uniqueInstances} instance created!");
            Console.ResetColor();
            Console.WriteLine("Lazy<T> handles all the thread-safety for us!");
        }
    }
}
