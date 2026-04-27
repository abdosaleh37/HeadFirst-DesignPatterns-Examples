using Ch01_TheStrategyPattern.Interfaces;

namespace Ch01_TheStrategyPattern.Behaviors.FlyBehaviors
{
    public class FlyWithWings : IFlyBehavior
    {
        public void Fly() => Console.WriteLine("I'm flying with wings!");
    }
}

