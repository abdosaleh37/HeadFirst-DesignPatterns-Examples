namespace Ch07A_TheAdapterPattern.Legacy
{
    public interface IEnumeration<T>
    {
        bool HasMoreElements();

        T NextElement();
    }
}
