using Intro_DuckBehaviors.Interfaces;

namespace Intro_DuckBehaviors.Behaviors.FlyBehaviors
{
    public class FlyNoWay : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("I can't fly");
        }
    }
}
