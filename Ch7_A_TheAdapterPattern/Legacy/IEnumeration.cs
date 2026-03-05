namespace Ch7_A_TheAdapterPattern.Legacy
{
    public interface IEnumeration<T>
    {
        bool HasMoreElements();

        T NextElement();
    }
}
