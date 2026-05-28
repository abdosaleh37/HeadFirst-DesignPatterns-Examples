using Ch08_TheTemplateMethodPattern.Abstracts;

namespace Ch08_TheTemplateMethodPattern.Beverages
{
    public class Coffee : CaffeineBeverage
    {
        protected override void Brew()
            => Console.WriteLine("  Dripping coffee through filter");

        protected override void AddCondiments()
            => Console.WriteLine("  Adding sugar and milk");
    }
}
