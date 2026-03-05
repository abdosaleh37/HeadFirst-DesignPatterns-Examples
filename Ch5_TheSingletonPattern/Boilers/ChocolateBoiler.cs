namespace Ch5_TheSingletonPattern.Boilers
{
    public class ChocolateBoiler
    {
        private bool isEmpty;
        private bool isBoiled;

        public static ChocolateBoiler Boiler { get; } = new ChocolateBoiler();

        private ChocolateBoiler()
        {
            isEmpty = true;
            isBoiled = false;
        }

        public void Fill()
        {
            if (IsEmpty())
            {
                isEmpty = false;
                isBoiled = false;
                Console.WriteLine("Filling the boiler with milk/chocolate mixture");
            }
        }

        public void Drain()
        {
            if (!IsEmpty() && IsBoiled())
            {
                Console.WriteLine("Draining the boiled milk and chocolate");
                isEmpty = true;
            }
        }

        public void Boil()
        {
            if (!IsEmpty() && !IsBoiled())
            {
                Console.WriteLine("Bringing the contents to a boil");
                isBoiled = true;
            }
        }

        public bool IsEmpty() => isEmpty;
        public bool IsBoiled() => isBoiled;
    }
}
