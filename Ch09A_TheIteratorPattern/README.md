# Chapter 9A - Iterator Pattern

> "Provide a way to access the elements of an aggregate object sequentially without exposing its underlying representation."  
> - Design Patterns: Elements of Reusable Object-Oriented Software

## Intent
Expose sequential access to a collection without revealing its internal structure.

## Also Known As
Cursor.

## Motivation
The waitress needs to print multiple menus that each use different internal data structures. An iterator lets her traverse any menu with the same interface, so she never sees the backing collection.

## Chapter Summary (From the Book)
The chapter starts with two restaurants that store items differently. The waitress knows both structures, so her code is brittle and violates encapsulation.

By introducing iterators, each menu provides a uniform traversal API. Later, the chapter shows how `IEnumerable<T>` and `IEnumerator<T>` are .NET's built-in iterator pattern, letting `foreach` and LINQ work across collections.

## Applicability
- Use when multiple collections need a consistent traversal API.
- Use when you want to hide the collection's internal representation.
- Use to provide multiple traversal strategies without changing clients.

## Structure
```
+-----------------+     +------------------+
| Aggregate       | --> | Iterator         |
| CreateIterator()|     | HasNext/Next     |
+-----------------+     +------------------+
```

## Participants
| Role | Class in This Project | Responsibility |
| --- | --- | --- |
| Iterator | `IIterator<T>` | Defines the traversal interface. |
| Aggregate | `IMenu` | Exposes `CreateIterator()`. |
| Concrete Iterator | `PancakeHouseMenuIterator`, `DinerMenuIterator` | Iterates over different structures. |
| Concrete Aggregate | `PancakeHouseMenu`, `DinerMenu` | Store items and create iterators. |
| Client | `Waitress`, `WaitressV2` | Prints menus using iterators. |

## Collaborations
The client requests an iterator from each menu and uses the iterator to read items sequentially without seeing the backing data.

## Consequences
- Hides collection internals from the client.
- Centralizes traversal logic and simplifies client code.
- Adds iterator classes, which increases object count.
- Supports multiple traversal strategies without changing collections.

## Implementation Notes
- `IMenu` and `IIterator<T>` mirror the classic GoF example.
- All menus also implement `IEnumerable<MenuItem>` to show the .NET iterator style.
- `WaitressV2` uses `foreach` and LINQ to traverse any `IEnumerable<MenuItem>`.

## Sample Code
```csharp
public interface IIterator<T>
{
    bool HasNext();
    T Next();
}

public interface IMenu
{
    IIterator<MenuItem> CreateIterator();
}
```

## Known Uses
- `IEnumerable<T>` and `IEnumerator<T>` in .NET collections.
- UI frameworks that provide cursor-style traversal of elements.
- Database result sets exposed through iterators.

## Related Patterns
- Composite often uses iterators to traverse trees.
- Factory Method can create iterators as part of the aggregate.

## Project File Map
```
Ch09A_TheIteratorPattern/
  Ch09A_TheIteratorPattern.csproj
  Program.cs
  Client/
  Interfaces/
  Iterators/
  Menus/
  Models/
```

## How to Run
`dotnet run --project Ch09A_TheIteratorPattern/Ch09A_TheIteratorPattern.csproj`
