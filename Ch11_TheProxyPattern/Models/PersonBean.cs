using Ch11_TheProxyPattern.Interfaces;

namespace Ch11_TheProxyPattern.Models;

public sealed class PersonBean(string name, string gender, string interests) : IPersonBean
{
    private int _ratingCount;
    private int _ratingTotal;

    public string Name { get; } = name;
    public string Gender { get; } = gender;
    public string Interests { get; private set; } = interests;
    public int HotOrNotRating => _ratingCount == 0 ? 0 : _ratingTotal / _ratingCount;

    public void SetInterests(string interests) => Interests = interests;

    public void SetHotOrNotRating(int rating)
    {
        _ratingTotal += rating;
        _ratingCount++;
    }
}
