namespace Ch3_TheDecoratorPattern_StarbuzzCoffee.Abstracts
{
    public abstract class CondimentDecorator : Beverage
    {
        public Beverage Beverage { get; set; } = null!;
    }
}
