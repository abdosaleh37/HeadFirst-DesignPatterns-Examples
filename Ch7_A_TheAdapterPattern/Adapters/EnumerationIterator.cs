using Ch7_A_TheAdapterPattern.Legacy;
using System.Collections;

namespace Ch7_A_TheAdapterPattern.Adapters
{
    public class EnumerationIterator<T> : IEnumerator<T>
    {
        private readonly IEnumeration<T> _enumeration;
        private T _current = default!;

        public EnumerationIterator(IEnumeration<T> enumeration) => _enumeration = enumeration;

        public T Current => _current;

        object? IEnumerator.Current => _current;

        public bool MoveNext()
        {
            if (_enumeration.HasMoreElements())
            {
                _current = _enumeration.NextElement();
                return true;
            }
            return false;
        }

        public void Reset() => throw new NotSupportedException("Enumeration does not support Reset.");

        public void Dispose() { }
    }
}
