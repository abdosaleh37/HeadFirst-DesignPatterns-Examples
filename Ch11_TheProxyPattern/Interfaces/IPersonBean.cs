namespace Ch11_TheProxyPattern.Interfaces;

public interface IPersonBean
{
    string Name { get; }
    string Gender { get; }
    string Interests { get; }
    int HotOrNotRating { get; }

    void SetInterests(string interests);
    void SetHotOrNotRating(int rating);
}
