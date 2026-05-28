using Ch07A_TheAdapterPattern.Abstracts;

namespace Ch07A_TheAdapterPattern.Models
{
    public class MallardDuck : Duck
    {
        public void Quack() => Console.WriteLine("Quack");

        public void Fly() => Console.WriteLine("I'm flying");
    }
}
