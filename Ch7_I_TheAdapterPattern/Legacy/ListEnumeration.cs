namespace Ch7_I_TheAdapterPattern.Legacy
{
    public class ListEnumeration<T> : IEnumeration<T>
    {
        private readonly List<T> _items;
        private int _index = 0;

        public ListEnumeration(List<T> items) => _items = items;

        public bool HasMoreElements() => _index < _items.Count;

        public T NextElement() => _items[_index++];
    }
}
