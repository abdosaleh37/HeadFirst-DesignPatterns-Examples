namespace Ch9_B_TheCompositePattern.Abstracts
{
    public abstract class MenuComponent
    {
        public virtual void Add(MenuComponent component)
            => throw new NotSupportedException();

        public virtual void Remove(MenuComponent component)
            => throw new NotSupportedException();

        public virtual MenuComponent GetChild(int i)
            => throw new NotSupportedException();

        public virtual string Name => throw new NotSupportedException();
        public virtual string Description => throw new NotSupportedException();
        public virtual double Price => throw new NotSupportedException();
        public virtual bool IsVegetarian => throw new NotSupportedException();

        public abstract void Print();
    }
}
