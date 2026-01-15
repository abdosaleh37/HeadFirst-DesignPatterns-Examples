using Intro_DuckBehaviors.Interfaces;

namespace Intro_DuckBehaviors.Behaviors.QuackBehaviors
{
    public class Squeak : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("Squeak squeak!");
        }
    }
}
