using Ch11_TheProxyPattern.Interfaces;

namespace Ch11_TheProxyPattern.Proxies;

public sealed class NonOwnerPersonProxy(IPersonBean personBean) : IPersonBean
{
    private readonly IPersonBean _personBean = personBean;

    public string Name => _personBean.Name;
    public string Gender => _personBean.Gender;
    public string Interests => _personBean.Interests;
    public int HotOrNotRating => _personBean.HotOrNotRating;

    public void SetInterests(string interests)
    {
        throw new InvalidOperationException("Non-owners cannot edit interests.");
    }

    public void SetHotOrNotRating(int rating) => _personBean.SetHotOrNotRating(rating);
}
