using Ch9_B_TheCompositePattern.Client;
using Ch9_B_TheCompositePattern.Models;

// ─────────────────────────────────────────────────────────────────────────────
//  CHAPTER 9B – THE COMPOSITE PATTERN
// ─────────────────────────────────────────────────────────────────────────────
PrintHeader("CHAPTER 9B – THE COMPOSITE PATTERN", '=');
Console.WriteLine(
    """
    The Composite Pattern composes objects into tree structures to represent
    part-whole hierarchies.  It lets clients treat individual objects (leaves)
    and compositions of objects (composites) uniformly.

    Pattern roles:
      • Component  — abstract base shared by leaves and composites
      • Leaf       — has no children; defines the primitive behavior
      • Composite  — holds children (MenuComponents); delegates Print() to them

    Trade-off: MenuComponent exposes both leaf AND composite operations in one
    type (transparency).  Non-applicable operations throw NotSupportedException
    rather than silently doing nothing.
    """);

// ─────────────────────────────────────────────────────────────────────────────
//  PART 1 – Building and Printing the Full Menu Tree
// ─────────────────────────────────────────────────────────────────────────────
PrintHeader("PART 1: Building and Printing the Full Menu Tree", '-');
Console.WriteLine(
    """
    Tree structure:
      ALL MENUS  (composite)
      ├── PANCAKE HOUSE MENU  (composite)
      │   ├── K&B's Pancake Breakfast          (leaf)
      │   ├── Regular Pancake Breakfast        (leaf)
      │   ├── Blueberry Pancakes               (leaf)
      │   └── Waffles                          (leaf)
      ├── DINER MENU  (composite)
      │   ├── Vegetarian BLT                   (leaf)
      │   ├── BLT                              (leaf)
      │   ├── Soup of the Day                  (leaf)
      │   ├── Hotdog                           (leaf)
      │   ├── Steamed Veggies and Brown Rice   (leaf)
      │   ├── Pasta                            (leaf)
      │   └── DESSERT MENU  (composite)   ← sub-menu embedded inside Diner Menu!
      │       ├── Apple Pie                    (leaf)
      │       ├── Cheesecake                   (leaf)
      │       └── Sorbet                       (leaf)
      └── CAFE MENU  (composite)
          ├── Veggie Burger and Air Fries      (leaf)
          ├── Soup of the Day                  (leaf)
          └── Burrito                          (leaf)

    The Waitress calls allMenus.Print() — it doesn't know or care whether
    Print() recurses into sub-menus or simply prints a single item.
    """);

var pancakeHouseMenu = new Menu("PANCAKE HOUSE MENU", "Breakfast");
pancakeHouseMenu.Add(new MenuItem("K&B's Pancake Breakfast", "Pancakes with scrambled eggs and toast", true, 2.99));
pancakeHouseMenu.Add(new MenuItem("Regular Pancake Breakfast", "Pancakes with fried eggs, sausage", false, 2.99));
pancakeHouseMenu.Add(new MenuItem("Blueberry Pancakes", "Pancakes made with fresh blueberries", true, 3.49));
pancakeHouseMenu.Add(new MenuItem("Waffles", "Waffles with your choice of blueberries or strawberries", true, 3.59));

var dessertMenu = new Menu("DESSERT MENU", "Desserts — end on a sweet note");
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
dinerMenu.Add(dessertMenu);   // composite added to composite!

var cafeMenu = new Menu("CAFE MENU", "Dinner");
cafeMenu.Add(new MenuItem("Veggie Burger and Air Fries", "Veggie burger on a whole wheat bun, lettuce, tomato, and fries", true, 3.99));
cafeMenu.Add(new MenuItem("Soup of the Day", "A cup of the soup of the day with a side salad", false, 3.69));
cafeMenu.Add(new MenuItem("Burrito", "A large burrito with whole pinto beans, salsa, guacamole", true, 4.29));

var allMenus = new Menu("ALL MENUS", "All menus combined");
allMenus.Add(pancakeHouseMenu);
allMenus.Add(dinerMenu);
allMenus.Add(cafeMenu);

var waitress = new Waitress(allMenus);
waitress.PrintMenu();

// ─────────────────────────────────────────────────────────────────────────────
//  PART 2 – Treating Leaves and Composites Uniformly
// ─────────────────────────────────────────────────────────────────────────────
PrintHeader("PART 2: Treating Leaves and Composites Uniformly", '-');
Console.WriteLine(
    """
    The defining power of the Composite Pattern: you can call Print() on ANY
    MenuComponent — a single MenuItem leaf OR an entire Menu sub-tree — and it
    just works.  The client code is identical in both cases.
    """);

Console.WriteLine("Printing only the DESSERT MENU (a sub-composite):");
dessertMenu.Print();

Console.WriteLine();
Console.WriteLine("Printing one MenuItem directly (a leaf):");
var singleItem = new MenuItem("Hotdog", "A hot dog with sauerkraut, relish, onions, topped with cheese", false, 3.05);
singleItem.Print();

// ─────────────────────────────────────────────────────────────────────────────
//  PART 3 – Dynamic Modification: Add and Remove Children
// ─────────────────────────────────────────────────────────────────────────────
PrintHeader("PART 3: Dynamic Modification — Add and Remove Components", '-');
Console.WriteLine(
    """
    Because Menu holds children in a List<MenuComponent>, components can be
    added or removed at runtime.  The tree re-renders correctly on the next
    Print() call — no special update logic needed.
    """);

cafeMenu.Add(new MenuItem("Late Night Special", "Two sliders and onion rings", false, 5.49));
dessertMenu.Remove(dessertMenu.GetChild(1));   // remove Cheesecake (index 1)

Console.WriteLine("Updated CAFE MENU after adding 'Late Night Special':");
cafeMenu.Print();

Console.WriteLine("\nUpdated DESSERT MENU after removing 'Cheesecake':");
dessertMenu.Print();

// ─────────────────────────────────────────────────────────────────────────────
//  Summary
// ─────────────────────────────────────────────────────────────────────────────
Console.WriteLine();
PrintHeader("SUMMARY", '=');
Console.WriteLine(
    """
    ┌────────────────────────────────────────────────────────────────────────────┐
    │                    Composite Pattern — Key Points                          │
    ├────────────────────────────────────────────────────────────────────────────┤
    │  • Composes objects into TREE structures (part-whole hierarchies)          │
    │  • Leaves and composites share one common Component type                   │
    │  • Clients treat individual objects and compositions uniformly             │
    │  • Composites delegate operations to their children (natural recursion)    │
    │  • Trade-off: Component must include both leaf AND composite ops,          │
    │    relaxing Single Responsibility in exchange for client simplicity        │
    │  • Found everywhere: file systems, UI widget trees, org charts,            │
    │    expression trees, scene graphs                                          │
    └────────────────────────────────────────────────────────────────────────────┘
    """);

static void PrintHeader(string title, char separator)
{
    string line = new string(separator, 79);
    Console.WriteLine();
    Console.WriteLine(line);
    Console.WriteLine($"  {title}");
    Console.WriteLine(line);
}

