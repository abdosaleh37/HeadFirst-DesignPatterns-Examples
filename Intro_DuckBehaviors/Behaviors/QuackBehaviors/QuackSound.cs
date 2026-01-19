using CH0_Intro_DuckBehaviors.Interfaces;

namespace CH0_Intro_DuckBehaviors.Behaviors.QuackBehaviors
{
    public class QuackSound : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("Quack quack!");
        }
    }
}
