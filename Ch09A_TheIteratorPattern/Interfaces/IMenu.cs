using Ch09A_TheIteratorPattern.Models;

namespace Ch09A_TheIteratorPattern.Interfaces
{
    public interface IMenu
    {
        string MenuName { get; }
        IIterator<MenuItem> CreateIterator();
    }
}
