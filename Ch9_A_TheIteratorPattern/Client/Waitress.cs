using Ch9_A_TheIteratorPattern.Interfaces;
using Ch9_A_TheIteratorPattern.Models;

namespace Ch9_A_TheIteratorPattern.Client
{
    public class Waitress
    {
        private readonly IMenu[] _menus;

        public Waitress(params IMenu[] menus) => _menus = menus;

        public void PrintMenu()
        {
            foreach (var menu in _menus)
            {
                Console.WriteLine($"\n{menu.MenuName}");
                Console.WriteLine(new string('-', 40));
                PrintItems(menu.CreateIterator());
            }
        }

        public void PrintVegetarianMenu()
        {
            Console.WriteLine("\nVEGETARIAN MENU");
            Console.WriteLine(new string('-', 40));
            foreach (var menu in _menus)
            {
                var iterator = menu.CreateIterator();
                while (iterator.HasNext())
                {
                    var item = iterator.Next();
                    if (item.IsVegetarian)
                        Console.WriteLine(item);
                }
            }
        }

        private static void PrintItems(IIterator<MenuItem> iterator)
        {
            while (iterator.HasNext())
                Console.WriteLine(iterator.Next());
        }
    }
}
