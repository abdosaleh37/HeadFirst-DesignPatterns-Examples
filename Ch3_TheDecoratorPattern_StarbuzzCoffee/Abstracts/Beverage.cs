namespace Ch3_TheDecoratorPattern_StarbuzzCoffee.Abstracts
{
    public abstract class Beverage
    {
        public string Description { get; set; } = "Unknown Beverage";

        public abstract double Cost();
    }
}
