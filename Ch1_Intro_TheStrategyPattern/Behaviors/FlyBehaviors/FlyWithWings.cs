using Ch1_Intro_TheStrategyPattern.Interfaces;

namespace Ch1_Intro_TheStrategyPattern.Behaviors.FlyBehaviors
{
    public class FlyWithWings : IFlyBehavior
    {
        public void Fly() => Console.WriteLine("I'm flying with wings!");
    }
}
