# Chapter 9B - Composite Pattern

> "Compose objects into tree structures to represent part-whole hierarchies. Composite lets clients treat individual objects and compositions of objects uniformly."  
> - Design Patterns: Elements of Reusable Object-Oriented Software

## Intent
Represent part-whole hierarchies with a single uniform interface for both leaves and composites.

## Also Known As
Part-Whole.

## Motivation
The menu system now contains nested sub-menus. The waitress should print the entire menu tree without special-case checks for leaf vs. submenu nodes.

## Chapter Summary (From the Book)
The chapter shows how a tree of menus becomes hard to handle if the client must distinguish menus from menu items. Composite introduces a shared component type so both leaves and composites can be treated the same.

The book stresses the transparency trade-off: the shared component exposes both leaf and composite operations, which simplifies clients while pushing some responsibility into runtime checks.

## Applicability
- Use when you need to represent hierarchical structures.
- Use when clients should treat leaves and composites uniformly.
- Use when you want to add new node types without changing clients.

## Structure
```
+------------------+
| MenuComponent    |
+------------------+
             ^
             |
    +----+----+
    |         |
Menu     MenuItem
```

## Participants
| Role | Class in This Project | Responsibility |
| --- | --- | --- |
| Component | `MenuComponent` | Defines the common interface. |
| Composite | `Menu` | Holds children and delegates operations. |
| Leaf | `MenuItem` | Represents a single menu entry. |
| Client | `Waitress` | Treats all components uniformly. |

## Collaborations
The client calls `Print()` on the root component. Composites delegate the call to their children, forming a recursive traversal of the tree.

## Consequences
- Simplifies client code by removing leaf/composite distinctions.
- Makes it easy to add new leaf or composite types.
- Trades some type safety for a uniform interface (unsupported operations throw).

## Implementation Notes
- `MenuComponent` defines leaf and composite operations with default throws.
- `Menu.GetChildren()` exposes child enumeration for traversal helpers.
- `MenuItem.Print()` formats a single item, including vegetarian marker.

## Sample Code
```csharp
public abstract class MenuComponent
{
        public virtual void Add(MenuComponent component) => throw new NotSupportedException();
        public virtual void Remove(MenuComponent component) => throw new NotSupportedException();
        public abstract void Print();
}
```

## Known Uses
- File systems (folders and files).
- UI widget trees.
- Organizational charts.

## Related Patterns
- Iterator can traverse composite trees.
- Decorator also uses a uniform interface but adds behavior rather than structure.

## Project File Map
```
Ch09B_TheCompositePattern/
    Ch09B_TheCompositePattern.csproj
    Program.cs
    Abstracts/
    Client/
    Models/
```

## How to Run
`dotnet run --project Ch09B_TheCompositePattern/Ch09B_TheCompositePattern.csproj`
