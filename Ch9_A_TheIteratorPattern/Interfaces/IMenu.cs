using Ch9_A_TheIteratorPattern.Models;

namespace Ch9_A_TheIteratorPattern.Interfaces
{
    public interface IMenu
    {
        string MenuName { get; }
        IIterator<MenuItem> CreateIterator();
    }
}
