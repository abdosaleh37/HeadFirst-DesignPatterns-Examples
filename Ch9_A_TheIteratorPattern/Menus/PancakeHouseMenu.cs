using System.Collections;
using Ch9_A_TheIteratorPattern.Interfaces;
using Ch9_A_TheIteratorPattern.Iterators;
using Ch9_A_TheIteratorPattern.Models;

namespace Ch9_A_TheIteratorPattern.Menus
{
    public class PancakeHouseMenu : IMenu, IEnumerable<MenuItem>
    {
        private readonly List<MenuItem> _items = new();

        public string MenuName => "Pancake House Menu — Breakfast";

        public PancakeHouseMenu()
        {
            _items.Add(new MenuItem("K&B's Pancake Breakfast", "Pancakes with scrambled eggs and toast", true, 2.99));
            _items.Add(new MenuItem("Regular Pancake Breakfast", "Pancakes with fried eggs, sausage", false, 2.99));
            _items.Add(new MenuItem("Blueberry Pancakes", "Pancakes made with fresh blueberries", true, 3.49));
            _items.Add(new MenuItem("Waffles", "Waffles with your choice of blueberries or strawberries", true, 3.59));
        }

        public IIterator<MenuItem> CreateIterator() => new PancakeHouseMenuIterator(_items);

        public IEnumerator<MenuItem> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
