using Ch07A_TheAdapterPattern.Abstracts;
using Ch07A_TheAdapterPattern.Adapters;
using Ch07A_TheAdapterPattern.Legacy;
using Ch07A_TheAdapterPattern.Models;

namespace Ch07A_TheAdapterPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintSection("Chapter 7A - Adapter Pattern");

            Console.WriteLine("Scenario 1: Ducks and turkeys");

            Duck duck = new MallardDuck();
            Turkey turkey = new WildTurkey();

            Duck turkeyAdapter = new TurkeyAdapter(turkey);
            Turkey duckAdapter = new DuckAdapter(duck);

            Console.WriteLine("Turkey:");
            TestTurkey(turkey);

            Console.WriteLine("\nDuck:");
            TestDuck(duck);

            Console.WriteLine("\nTurkeyAdapter as Duck:");
            TestDuck(turkeyAdapter);

            Console.WriteLine("\nDuckAdapter as Turkey:");
            TestTurkey(duckAdapter);

            PrintSection("Scenario 2: Enumeration to Iterator");

            var names = new List<string> { "Alice", "Bob", "Charlie", "Dave" };
            IEnumeration<string> enumeration = new ListEnumeration<string>(names);
            IEnumerator<string> iterator = new EnumerationIterator<string>(enumeration);

            while (iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current);
            }
        }

        static void TestDuck(Duck duck)
        {
            duck.Quack();
            duck.Fly();
        }

        static void TestTurkey(Turkey turkey)
        {
            turkey.Gobble();
            turkey.Fly();
        }

        static void PrintSection(string title)
        {
            Console.WriteLine();
            Console.WriteLine(new string('-', 60));
            Console.WriteLine(title);
            Console.WriteLine(new string('-', 60));
        }
    }
}
