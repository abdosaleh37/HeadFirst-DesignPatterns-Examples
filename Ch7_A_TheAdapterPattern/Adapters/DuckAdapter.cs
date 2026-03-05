using Ch7_A_TheAdapterPattern.Abstracts;

namespace Ch7_A_TheAdapterPattern.Adapters
{
    public class DuckAdapter : Turkey
    {
        private readonly Duck _duck;
        private readonly Random _random;

        public DuckAdapter(Duck duck)
        {
            _duck = duck;
            _random = new Random();
        }

        public void Fly()
        {
            if (_random.Next(5) == 0)
            {
                _duck.Fly();
            }
        }

        public void Gobble() => _duck.Quack();
    }
}
