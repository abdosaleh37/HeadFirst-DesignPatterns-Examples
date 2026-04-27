using Ch01_TheStrategyPattern.Interfaces;

namespace Ch01_TheStrategyPattern.Behaviors.FlyBehaviors
{
    public class FlyRocketPowered : IFlyBehavior
    {
        public void Fly() => Console.WriteLine("I'm flying with a rocket!");
    }
}

