using Intro_DuckBehaviors.Interfaces;

namespace Intro_DuckBehaviors.Models
{
    public abstract class Duck
    {
        public Duck() { }

        private IFlyBehavior _flyBehavior = null!;
        private IQuackBehavior _quackBehavior = null!;

        public IFlyBehavior FlyBehavior
        {
            set
            {
                _flyBehavior = value;
            }
        }

        public IQuackBehavior QuackBehavior
        {
            set
            {
                _quackBehavior = value;
            }
        }

        public void PerformFly()
        {
            _flyBehavior.Fly();
        }

        public void PerformQuack()
        {
            _quackBehavior.Quack();
        }

        public virtual void Swim()
        {
            Console.WriteLine("All ducks float, even decoys!");
        }

        public abstract void Display();
    }
}
