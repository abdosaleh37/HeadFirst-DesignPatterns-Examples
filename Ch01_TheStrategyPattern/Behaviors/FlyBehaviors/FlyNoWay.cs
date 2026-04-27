using Ch01_TheStrategyPattern.Interfaces;

namespace Ch01_TheStrategyPattern.Behaviors.FlyBehaviors
{
    public class FlyNoWay : IFlyBehavior
    {
        public void Fly() => Console.WriteLine("I can't fly");
    }
}

