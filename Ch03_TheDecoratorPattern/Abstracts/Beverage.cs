namespace Ch03_TheDecoratorPattern.Abstracts
{
    public abstract class Beverage
    {
        public string Description { get; set; } = "Unknown Beverage";

        public abstract double Cost();
    }
}

