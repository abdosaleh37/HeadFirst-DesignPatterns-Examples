namespace Ch14_Appendix.Prototype;

public static class PrototypeDemo
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("--- Prototype Pattern ---");

        var original = new CharacterSheet("Rogue", 12, new[] { "Stealth", "Lockpick" });
        CharacterSheet clone = original.Clone();
        clone.Name = "Rogue Copy";

        Console.WriteLine($"Original: {original.Name} | Skills: {string.Join(", ", original.Skills)}");
        Console.WriteLine($"Clone: {clone.Name} | Skills: {string.Join(", ", clone.Skills)}");
    }
}
