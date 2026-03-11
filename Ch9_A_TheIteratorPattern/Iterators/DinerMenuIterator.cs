using Ch9_A_TheIteratorPattern.Interfaces;
using Ch9_A_TheIteratorPattern.Models;

namespace Ch9_A_TheIteratorPattern.Iterators
{
    public class DinerMenuIterator : IIterator<MenuItem>
    {
        private readonly MenuItem?[] _items;
        private int _position = 0;

        public DinerMenuIterator(MenuItem?[] items) => _items = items;

        public bool HasNext()
            => _position < _items.Length && _items[_position] is not null;

        public MenuItem Next() => _items[_position++]!;
    }
}
