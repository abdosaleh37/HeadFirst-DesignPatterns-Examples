using Ch11_TheProxyPattern.Interfaces;

namespace Ch11_TheProxyPattern.Proxies;

public sealed class OwnerPersonProxy(IPersonBean personBean) : IPersonBean
{
    private readonly IPersonBean _personBean = personBean;

    public string Name => _personBean.Name;
    public string Gender => _personBean.Gender;
    public string Interests => _personBean.Interests;
    public int HotOrNotRating => _personBean.HotOrNotRating;

    public void SetInterests(string interests) => _personBean.SetInterests(interests);

    public void SetHotOrNotRating(int rating)
    {
        throw new InvalidOperationException("Owners cannot set their own rating.");
    }
}
