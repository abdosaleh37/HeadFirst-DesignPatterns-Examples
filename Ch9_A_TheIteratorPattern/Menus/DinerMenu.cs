using System.Collections;
using Ch9_A_TheIteratorPattern.Interfaces;
using Ch9_A_TheIteratorPattern.Iterators;
using Ch9_A_TheIteratorPattern.Models;

namespace Ch9_A_TheIteratorPattern.Menus
{
    public class DinerMenu : IMenu, IEnumerable<MenuItem>
    {
        private const int MaxItems = 6;
        private int _count = 0;
        private readonly MenuItem?[] _items = new MenuItem?[MaxItems];

        public string MenuName => "Diner Menu — Lunch";

        public DinerMenu()
        {
            Add("Vegetarian BLT", "Fakin' Bacon with lettuce & tomato on whole wheat", true, 2.99);
            Add("BLT", "Bacon with lettuce & tomato on whole wheat", false, 2.99);
            Add("Soup of the Day", "Soup of the day with a side of potato salad", false, 3.29);
            Add("Hotdog", "A hot dog with sauerkraut, relish, onions, topped with cheese", false, 3.05);
            Add("Steamed Veggies and Brown Rice", "A healthy plate of steamed veggies and brown rice", true, 3.99);
            Add("Pasta", "Spaghetti with marinara sauce and a slice of sourdough bread", true, 3.89);
        }

        private void Add(string name, string description, bool isVegetarian, double price)
        {
            if (_count < MaxItems)
                _items[_count++] = new MenuItem(name, description, isVegetarian, price);
        }

        public IIterator<MenuItem> CreateIterator() => new DinerMenuIterator(_items);

        public IEnumerator<MenuItem> GetEnumerator()
            => _items.Take(_count).OfType<MenuItem>().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
