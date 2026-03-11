using Ch8_TheTemplateMethodPattern.Abstracts;

namespace Ch8_TheTemplateMethodPattern.Beverages
{
    public class CoffeeWithHook : CaffeineBeverage
    {
        protected override void Brew() 
            => Console.WriteLine("  Dripping coffee through filter");

        protected override void AddCondiments()
            => Console.WriteLine("  Adding sugar and milk");

        protected override bool CustomerWantsCondiments()
        {
            string? answer = GetUserInput();
            return answer?.ToLower().StartsWith("y") ?? true;
        }

        private static string? GetUserInput()
        {
            Console.Write("  Would you like milk and sugar with your coffee (y/n)? ");
            return Console.ReadLine();
        }
    }
}
