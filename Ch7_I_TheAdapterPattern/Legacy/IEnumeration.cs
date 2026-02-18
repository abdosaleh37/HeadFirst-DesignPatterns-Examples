namespace Ch7_I_TheAdapterPattern.Legacy
{
    public interface IEnumeration<T>
    {
        bool HasMoreElements();

        T NextElement();
    }
}
