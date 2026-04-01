namespace Ch14_Appendix.Flyweight;

public sealed class TreeTypeFactory
{
    private readonly Dictionary<string, TreeType> _cache = new();

    public int Count => _cache.Count;

    public TreeType GetTreeType(string name, string color)
    {
        string key = $"{name}:{color}";
        if (_cache.TryGetValue(key, out TreeType? existing))
        {
            return existing;
        }

        var created = new TreeType(name, color);
        _cache[key] = created;
        return created;
    }
}
