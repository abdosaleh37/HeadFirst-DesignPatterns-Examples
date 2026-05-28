using Ch09B_TheCompositePattern.Abstracts;

namespace Ch09B_TheCompositePattern.Models
{
    public class Menu : MenuComponent
    {
        private readonly List<MenuComponent> _components = new();

        public override string Name { get; }
        public override string Description { get; }

        public Menu(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public override void Add(MenuComponent component) => _components.Add(component);

        public override void Remove(MenuComponent component) => _components.Remove(component);

        public override MenuComponent GetChild(int i) => _components[i];

        public override IEnumerable<MenuComponent> GetChildren() => _components;

        public override void Print()
        {
            Console.WriteLine($"\n{Name}");
            Console.WriteLine($"  {Description}");
            Console.WriteLine(new string('-', 40));
            foreach (var component in _components)
                component.Print();
        }
    }
}
