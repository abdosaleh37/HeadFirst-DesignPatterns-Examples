using Ch09A_TheIteratorPattern.Client;
using Ch09A_TheIteratorPattern.Menus;

PrintSection("Chapter 9A - Iterator Pattern");

var pancakeMenu = new PancakeHouseMenu();
var dinerMenu = new DinerMenu();
var cafeMenu = new CafeMenu();

Console.WriteLine("Waitress prints all menus using IEnumerable<T>:");
var waitress = new WaitressV2(
    (pancakeMenu.MenuName, pancakeMenu),
    (dinerMenu.MenuName, dinerMenu),
    (cafeMenu.MenuName, cafeMenu)
);

waitress.PrintMenu();

static void PrintSection(string title)
{
    Console.WriteLine();
    Console.WriteLine(new string('-', 60));
    Console.WriteLine(title);
    Console.WriteLine(new string('-', 60));
}

