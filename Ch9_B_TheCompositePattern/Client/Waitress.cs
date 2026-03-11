using Ch9_B_TheCompositePattern.Abstracts;

namespace Ch9_B_TheCompositePattern.Client
{
    public class Waitress
    {
        private readonly MenuComponent _allMenus;

        public Waitress(MenuComponent allMenus) => _allMenus = allMenus;

        public void PrintMenu() => _allMenus.Print();
    }
}
