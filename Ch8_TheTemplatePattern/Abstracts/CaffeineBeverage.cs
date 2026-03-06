namespace Ch8_TheTemplatePattern.Abstracts
{
    public abstract class CaffeineBeverage
    {
        public void PrepareRecipe()
        {
            BoilWater();
            Brew();
            PourInCup();
            if (CustomerWantsCondiments())   // ← hook guards this step
                AddCondiments();
        }

        protected abstract void Brew();

        protected abstract void AddCondiments();

        private void BoilWater()
            => Console.WriteLine("  Boiling water");

        private void PourInCup()
            => Console.WriteLine("  Pouring into cup");

        // Hook — subclasses MAY override, but don't have to
        protected virtual bool CustomerWantsCondiments() => true;
    }
}
