using Ch7_A_TheAdapterPattern.Abstracts;
using Ch7_A_TheAdapterPattern.Adapters;
using Ch7_A_TheAdapterPattern.Legacy;
using Ch7_A_TheAdapterPattern.Models;

namespace Ch7_A_TheAdapterPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // --- Duck / Turkey Adapter Demo ---
            Duck duck = new MallardDuck();
            Turkey turkey = new WildTurkey();

            Duck turkeyAdapter = new TurkeyAdapter(turkey);
            Turkey duckAdapter = new DuckAdapter(duck);

            Console.WriteLine("The Turkey says...");
            TestTurkey(turkey);

            Console.WriteLine("\nThe Duck says...");
            TestDuck(duck);

            Console.WriteLine("\nThe TurkeyAdapter says...");
            TestDuck(turkeyAdapter);

            Console.WriteLine("\nThe DuckAdapter says...");
            TestTurkey(duckAdapter);

            // --- Enumeration to Iterator Adapter Demo ---
            Console.WriteLine("\n--- Enumeration to Iterator Adapter Demo ---");

            var names = new List<string> { "Alice", "Bob", "Charlie", "Dave" };
            IEnumeration<string> enumeration = new ListEnumeration<string>(names);
            IEnumerator<string> iterator = new EnumerationIterator<string>(enumeration);

            Console.WriteLine("Iterating over names using EnumerationIterator:");
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
    }
}
