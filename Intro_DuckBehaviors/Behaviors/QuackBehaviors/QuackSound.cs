using Intro_DuckBehaviors.Interfaces;

namespace Intro_DuckBehaviors.Behaviors.QuackBehaviors
{
    public class QuackSound : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("Quack quack!");
        }
    }
}
