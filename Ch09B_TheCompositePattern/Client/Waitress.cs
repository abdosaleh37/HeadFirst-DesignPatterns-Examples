using Ch09B_TheCompositePattern.Abstracts;

namespace Ch09B_TheCompositePattern.Client
{
    public class Waitress
    {
        private readonly MenuComponent _allMenus;

        public Waitress(MenuComponent allMenus) => _allMenus = allMenus;

        public void PrintMenu() => _allMenus.Print();
    }
}
