using Ch07A_TheAdapterPattern.Abstracts;

namespace Ch07A_TheAdapterPattern.Models
{
    public class WildTurkey : Turkey
    {
        public void Gobble() => Console.WriteLine("Gobble gobble");

        public void Fly() => Console.WriteLine("I'm flying a short distance");
    }
}
