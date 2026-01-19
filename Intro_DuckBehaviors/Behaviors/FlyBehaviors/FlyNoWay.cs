using CH0_Intro_DuckBehaviors.Interfaces;

namespace CH0_Intro_DuckBehaviors.Behaviors.FlyBehaviors
{
    public class FlyNoWay : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("I can't fly");
        }
    }
}
