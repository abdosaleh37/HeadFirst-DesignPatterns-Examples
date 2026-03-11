using Ch9_A_TheIteratorPattern.Interfaces;
using Ch9_A_TheIteratorPattern.Models;

namespace Ch9_A_TheIteratorPattern.Iterators
{
    public class PancakeHouseMenuIterator : IIterator<MenuItem>
    {
        private readonly List<MenuItem> _items;
        private int _position = 0;

        public PancakeHouseMenuIterator(List<MenuItem> items) => _items = items;

        public bool HasNext() => _position < _items.Count;

        public MenuItem Next() => _items[_position++];
    }
}
