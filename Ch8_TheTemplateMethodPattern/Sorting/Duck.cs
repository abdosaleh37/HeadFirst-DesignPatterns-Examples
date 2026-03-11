namespace Ch8_TheTemplateMethodPattern.Sorting
{
    public class Duck : IComparable<Duck>
    {
        public string Name { get; }
        public int Weight { get; }

        public Duck(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }

        public int CompareTo(Duck? other)
        {
            if (other is null) return 1;
            return Weight.CompareTo(other.Weight);
        }

        public override string ToString() 
            => $"  {Name} weighs {Weight} lbs";
    }
}
