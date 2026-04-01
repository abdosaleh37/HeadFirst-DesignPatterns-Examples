namespace Ch14_Appendix.Prototype;

public interface IPrototype<out T>
{
    T Clone();
}
