namespace Ch9_A_TheIteratorPattern.Interfaces
{
    public interface IIterator<T>
    {
        bool HasNext();
        T Next();
    }
}
