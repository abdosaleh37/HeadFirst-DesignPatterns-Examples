namespace Ch3_TheDecoratorPattern.Abstracts
{
    public abstract class CondimentDecorator : Beverage
    {
        public Beverage Beverage { get; set; } = null!;
    }
}
