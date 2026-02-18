using Ch7_I_TheAdapterPattern.Abstracts;

namespace Ch7_I_TheAdapterPattern.Models
{
    public class MallardDuck : Duck
    {
        public void Quack() => Console.WriteLine("Quack");

        public void Fly() => Console.WriteLine("I'm flying");
    }
}
