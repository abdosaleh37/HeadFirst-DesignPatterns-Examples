using Ch08_TheTemplateMethodPattern.Abstracts;

namespace Ch08_TheTemplateMethodPattern.Beverages
{
    public class Tea : CaffeineBeverage
    {
        protected override void Brew() 
            => Console.WriteLine("  Steeping the tea");

        protected override void AddCondiments() 
            => Console.WriteLine("  Adding lemon");
    }
}
