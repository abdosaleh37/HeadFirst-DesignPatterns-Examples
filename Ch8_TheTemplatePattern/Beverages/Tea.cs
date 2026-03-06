using Ch8_TheTemplatePattern.Abstracts;

namespace Ch8_TheTemplatePattern.Beverages
{
    public class Tea : CaffeineBeverage
    {
        protected override void Brew() 
            => Console.WriteLine("  Steeping the tea");

        protected override void AddCondiments() 
            => Console.WriteLine("  Adding lemon");
    }
}
