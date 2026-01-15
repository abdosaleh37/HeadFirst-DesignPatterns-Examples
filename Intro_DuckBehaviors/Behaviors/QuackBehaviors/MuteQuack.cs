using Intro_DuckBehaviors.Interfaces;

namespace Intro_DuckBehaviors.Behaviors.QuackBehaviors
{
    public class MuteQuack : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("<< Silence >>");
        }
    }
}
