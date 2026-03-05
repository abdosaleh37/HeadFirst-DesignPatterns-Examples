using Ch1_Intro_TheStrategyPattern.Interfaces;

namespace Ch1_Intro_TheStrategyPattern.Behaviors.FlyBehaviors
{
    public class FlyRocketPowered : IFlyBehavior
    {
        public void Fly() => Console.WriteLine("I'm flying with a rocket!");
    }
}
