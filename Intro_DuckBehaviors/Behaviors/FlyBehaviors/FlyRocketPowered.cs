using Intro_DuckBehaviors.Interfaces;

namespace Intro_DuckBehaviors.Behaviors.FlyBehaviors
{
    public class FlyRocketPowered : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("I'm flying with a rocket!");
        }
    }
}
