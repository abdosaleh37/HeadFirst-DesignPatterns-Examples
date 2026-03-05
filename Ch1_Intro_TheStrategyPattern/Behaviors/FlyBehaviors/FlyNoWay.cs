using Ch1_Intro_TheStrategyPattern.Interfaces;

namespace Ch1_Intro_TheStrategyPattern.Behaviors.FlyBehaviors
{
    public class FlyNoWay : IFlyBehavior
    {
        public void Fly() => Console.WriteLine("I can't fly");
    }
}
