using CH0_Intro_DuckBehaviors.Interfaces;

namespace CH0_Intro_DuckBehaviors.Behaviors.QuackBehaviors
{
    public class Squeak : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("Squeak squeak!");
        }
    }
}
