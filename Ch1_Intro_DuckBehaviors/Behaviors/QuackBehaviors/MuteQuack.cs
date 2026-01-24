using Ch1_Intro_DuckBehaviors.Interfaces;

namespace Ch1_Intro_DuckBehaviors.Behaviors.QuackBehaviors
{
    public class MuteQuack : IQuackBehavior
    {
        public void Quack() => Console.WriteLine("<< Silence >>");
    }
}
