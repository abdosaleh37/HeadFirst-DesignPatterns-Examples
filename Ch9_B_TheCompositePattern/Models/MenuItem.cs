using Ch9_B_TheCompositePattern.Abstracts;

namespace Ch9_B_TheCompositePattern.Models
{
    public class MenuItem : MenuComponent
    {
        public override string Name { get; }
        public override string Description { get; }
        public override bool IsVegetarian { get; }
        public override double Price { get; }

        public MenuItem(string name, string description, bool isVegetarian, double price)
        {
            Name = name;
            Description = description;
            IsVegetarian = isVegetarian;
            Price = price;
        }

        public override void Print()
            => Console.WriteLine($"  {Name} (${Price:F2}){(IsVegetarian ?
                " [V]" : "")}\n    {Description}");
    }
}
