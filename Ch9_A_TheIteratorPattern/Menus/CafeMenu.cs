using System.Collections;
using Ch9_A_TheIteratorPattern.Models;

namespace Ch9_A_TheIteratorPattern.Menus
{
    public class CafeMenu : IEnumerable<MenuItem>
    {
        private readonly Dictionary<string, MenuItem> _items = new();

        public string MenuName => "Cafe Menu — Dinner";

        public CafeMenu()
        {
            _items["Veggie Burger"] = new MenuItem("Veggie Burger and Air Fries",
                "Veggie burger on a whole wheat bun, lettuce, tomato, and fries", true, 3.99);
            _items["Soup of the Day"] = new MenuItem("Soup of the Day",
                "A cup of the soup of the day with a side salad", false, 3.69);
            _items["Burrito"] = new MenuItem("Burrito",
                "A large burrito with whole pinto beans, salsa, guacamole", true, 4.29);
        }

        public IEnumerator<MenuItem> GetEnumerator() => _items.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
