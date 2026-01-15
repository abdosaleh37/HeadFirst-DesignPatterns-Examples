using Intro_DuckBehaviors.Interfaces;

namespace Intro_DuckBehaviors.Behaviors.FlyBehaviors
{
    public class FlyWithWings : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("I'm flying with wings!");
        }
    }
}
