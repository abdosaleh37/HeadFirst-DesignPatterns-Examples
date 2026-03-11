using Ch9_A_TheIteratorPattern.Models;

namespace Ch9_A_TheIteratorPattern.Client
{
    public class WaitressV2
    {
        private readonly (string Name, IEnumerable<MenuItem> Items)[] _menus;

        public WaitressV2(params (string Name, IEnumerable<MenuItem> Items)[] menus)
            => _menus = menus;

        public void PrintMenu()
        {
            foreach (var (name, items) in _menus)
            {
                Console.WriteLine($"\n{name}");
                Console.WriteLine(new string('-', 40));
                foreach (var item in items)
                    Console.WriteLine(item);
            }
        }

        public void PrintVegetarianMenu()
        {
            Console.WriteLine("\nVEGETARIAN MENU");
            Console.WriteLine(new string('-', 40));
            foreach (var (_, items) in _menus)
                foreach (var item in items.Where(i => i.IsVegetarian))
                    Console.WriteLine(item);
        }
    }
}
