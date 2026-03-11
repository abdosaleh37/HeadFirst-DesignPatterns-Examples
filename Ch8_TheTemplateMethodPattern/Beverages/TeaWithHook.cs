using Ch8_TheTemplateMethodPattern.Abstracts;

namespace Ch8_TheTemplateMethodPattern.Beverages
{
    public class TeaWithHook : CaffeineBeverage
    {
        protected override void Brew() 
            => Console.WriteLine("  Steeping the tea");

        protected override void AddCondiments() 
            => Console.WriteLine("  Adding lemon");

        protected override bool CustomerWantsCondiments()
        {
            string? answer = GetUserInput();
            return answer?.ToLower().StartsWith("y") ?? true;
        }

        private static string? GetUserInput()
        {
            Console.Write("  Would you like lemon with your tea (y/n)? ");
            return Console.ReadLine();
        }
    }
}
