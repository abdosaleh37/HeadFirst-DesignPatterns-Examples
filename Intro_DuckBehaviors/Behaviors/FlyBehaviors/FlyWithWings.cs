using CH0_Intro_DuckBehaviors.Interfaces;

namespace CH0_Intro_DuckBehaviors.Behaviors.FlyBehaviors
{
    public class FlyWithWings : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("I'm flying with wings!");
        }
    }
}
