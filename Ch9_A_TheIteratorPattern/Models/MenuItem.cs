namespace Ch9_A_TheIteratorPattern.Models
{
    public class MenuItem
    {
        public string Name { get; }
        public string Description { get; }
        public bool IsVegetarian { get; }
        public double Price { get; }

        public MenuItem(string name, string description, bool isVegetarian, double price)
        {
            Name = name;
            Description = description;
            IsVegetarian = isVegetarian;
            Price = price;
        }

        public override string ToString()
            => $"  {Name} (${Price:F2}){(IsVegetarian ?
                " [V]" : "")}\n    {Description}";
    }
}
