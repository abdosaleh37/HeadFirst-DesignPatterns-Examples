using Ch09B_TheCompositePattern.Abstracts;
using Ch09B_TheCompositePattern.Client;
using Ch09B_TheCompositePattern.Models;

PrintSection("Chapter 9B - Composite Pattern");

PrintSection("1) Build menu tree");
var allMenus = BuildMenuTree();

PrintSection("2) Print full menu");
new Waitress(allMenus).PrintMenu();

PrintSection("3) Print vegetarian items");
PrintVegetarian(allMenus);

static MenuComponent BuildMenuTree()
{
    var pancakeHouseMenu = new Menu("PANCAKE HOUSE MENU", "Breakfast");
    pancakeHouseMenu.Add(new MenuItem("K&B's Pancake Breakfast", "Pancakes with scrambled eggs and toast", true, 2.99));
    pancakeHouseMenu.Add(new MenuItem("Regular Pancake Breakfast", "Pancakes with fried eggs, sausage", false, 2.99));
    pancakeHouseMenu.Add(new MenuItem("Blueberry Pancakes", "Pancakes made with fresh blueberries", true, 3.49));
    pancakeHouseMenu.Add(new MenuItem("Waffles", "Waffles with your choice of blueberries or strawberries", true, 3.59));

    var dessertMenu = new Menu("DESSERT MENU", "Desserts");
    dessertMenu.Add(new MenuItem("Apple Pie", "Apple pie with a flaky crust, topped with vanilla ice cream", true, 1.59));
    dessertMenu.Add(new MenuItem("Cheesecake", "Creamy New York cheesecake with a chocolate graham crust", true, 1.99));
    dessertMenu.Add(new MenuItem("Sorbet", "A scoop of raspberry and a scoop of lime", true, 1.89));

    var dinerMenu = new Menu("DINER MENU", "Lunch");
    dinerMenu.Add(new MenuItem("Vegetarian BLT", "Fakin' Bacon with lettuce & tomato on whole wheat", true, 2.99));
    dinerMenu.Add(new MenuItem("BLT", "Bacon with lettuce & tomato on whole wheat", false, 2.99));
    dinerMenu.Add(new MenuItem("Soup of the Day", "Soup of the day with a side of potato salad", false, 3.29));
    dinerMenu.Add(new MenuItem("Hotdog", "A hot dog with sauerkraut, relish, onions, topped with cheese", false, 3.05));
    dinerMenu.Add(new MenuItem("Steamed Veggies and Brown Rice", "A healthy plate of steamed veggies and brown rice", true, 3.99));
    dinerMenu.Add(new MenuItem("Pasta", "Spaghetti with marinara sauce and a slice of sourdough bread", true, 3.89));
    dinerMenu.Add(dessertMenu);

    var cafeMenu = new Menu("CAFE MENU", "Dinner");
    cafeMenu.Add(new MenuItem("Veggie Burger and Air Fries", "Veggie burger on a whole wheat bun, lettuce, tomato, and fries", true, 3.99));
    cafeMenu.Add(new MenuItem("Soup of the Day", "A cup of the soup of the day with a side salad", false, 3.69));
    cafeMenu.Add(new MenuItem("Burrito", "A large burrito with whole pinto beans, salsa, guacamole", true, 4.29));

    var allMenus = new Menu("ALL MENUS", "All menus combined");
    allMenus.Add(pancakeHouseMenu);
    allMenus.Add(dinerMenu);
    allMenus.Add(cafeMenu);

    return allMenus;
}

static void PrintVegetarian(MenuComponent component)
{
    if (component is MenuItem item)
    {
        if (item.IsVegetarian)
            item.Print();
        return;
    }

    foreach (var child in component.GetChildren())
        PrintVegetarian(child);
}

static void PrintSection(string title)
{
    Console.WriteLine();
    Console.WriteLine(new string('-', 60));
    Console.WriteLine(title);
    Console.WriteLine(new string('-', 60));
}

