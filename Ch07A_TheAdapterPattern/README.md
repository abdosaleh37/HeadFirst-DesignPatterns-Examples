# Chapter 7A - Adapter Pattern

> "Convert the interface of a class into another interface clients expect. Adapter lets classes work together that couldn't otherwise because of incompatible interfaces."  
> - Design Patterns: Elements of Reusable Object-Oriented Software

## Intent
Translate one interface into another so existing classes can collaborate without changing their code.

## Also Known As
Wrapper.

## Motivation
The duck simulator speaks `Duck`, but the turkey only knows how to `Gobble`. An adapter wraps the turkey and makes it quack like a duck, letting the existing duck-based code reuse the turkey.

## Chapter Summary (From the Book)
The book starts with a duck interface and a turkey interface that are similar but incompatible. Instead of changing either class, it introduces an adapter that implements the expected interface and translates calls to the adaptee.

Later, the chapter demonstrates how adapters help migrate legacy APIs by converting an old enumeration interface into a modern iterator interface. The pattern lets new code work with old interfaces without a big rewrite.

## Applicability
- Use when you need to reuse an existing class with an incompatible interface.
- Use when client code should not change but the data source or API does.
- Use to bridge legacy code to modern interfaces.

## Structure
```
+------------------+      +-----------------+      +------------------+
| Client (Duck)    | ---> | TurkeyAdapter   | ---> | Turkey (Adaptee) |
+------------------+      +-----------------+      +------------------+
```

## Participants
| Role | Class in This Project | Responsibility |
| --- | --- | --- |
| Target | `Duck` | Interface the client expects. |
| Adaptee | `Turkey` | Existing interface that does not match. |
| Adapter | `TurkeyAdapter` | Implements `Duck` and wraps a `Turkey`. |
| Adapter | `DuckAdapter` | Implements `Turkey` and wraps a `Duck`. |
| Adapter | `EnumerationIterator` | Wraps `IEnumeration<T>` as `IEnumerator<T>`. |
| Client | `Program` | Uses `Duck` and `IEnumerator<T>` APIs. |

## Collaborations
The client works with `Duck` and `IEnumerator<T>`. The adapters translate each call into the adaptee's language so the client remains unchanged.

## Consequences
- Enables reuse of existing classes without modifying them.
- Keeps clients stable while implementation changes underneath.
- Adds extra object layers and translation code.
- Can obscure behavior when adapters do more than simple translation.

## Implementation Notes
- `TurkeyAdapter.Fly()` calls the turkey's short `Fly()` multiple times to simulate a duck flight.
- `DuckAdapter.Fly()` triggers the duck flight occasionally to mimic turkey flight length.
- `EnumerationIterator.Reset()` throws `NotSupportedException` to match the legacy API limitations.

## Sample Code
```csharp
public sealed class TurkeyAdapter : Duck
{
    private readonly Turkey _turkey;

    public TurkeyAdapter(Turkey turkey) => _turkey = turkey;

    public void Quack() => _turkey.Gobble();

    public void Fly()
    {
        for (int i = 0; i < 5; i++)
            _turkey.Fly();
    }
}
```

## Known Uses
- `StreamReader` adapts a byte `Stream` into a text reader interface.
- `DbDataAdapter` adapts database commands into a unified dataset API.
- `IEnumerator` wrappers often adapt custom enumerations into `foreach`-ready iterators.

## Related Patterns
- Facade provides a simplified interface rather than translation.
- Decorator adds responsibilities without changing the interface.
- Proxy controls access while keeping the same interface.

## Project File Map
```
Ch07A_TheAdapterPattern/
  Ch07A_TheAdapterPattern.csproj
  Program.cs
  Abstracts/
  Adapters/
  Legacy/
  Models/
```

## How to Run
`dotnet run --project Ch07A_TheAdapterPattern/Ch07A_TheAdapterPattern.csproj`
