using Ch07A_TheAdapterPattern.Abstracts;

namespace Ch07A_TheAdapterPattern.Adapters
{
    public class TurkeyAdapter : Duck
    {
        private readonly Turkey _turkey;

        public TurkeyAdapter(Turkey turkey) => _turkey = turkey;

        public void Fly()
        {
            for (int i = 0; i < 5; i++)
            {
                _turkey.Fly();
            }
        }

        public void Quack() => _turkey.Gobble();
    }
}
