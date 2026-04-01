namespace Ch14_Appendix.Prototype;

public sealed class CharacterSheet : IPrototype<CharacterSheet>
{
    public CharacterSheet(string name, int level, IEnumerable<string> skills)
    {
        Name = name;
        Level = level;
        Skills = skills.ToList();
    }

    public string Name { get; set; }
    public int Level { get; }
    public List<string> Skills { get; }

    public CharacterSheet Clone()
    {
        return new CharacterSheet(Name, Level, Skills);
    }
}
