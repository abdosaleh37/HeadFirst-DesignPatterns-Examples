namespace Ch03_TheDecoratorPattern.Abstracts
{
    public abstract class CondimentDecorator : Beverage
    {
        public Beverage Beverage { get; set; } = null!;
    }
}

