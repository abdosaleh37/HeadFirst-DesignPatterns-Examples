# Chapter 5 - Singleton Pattern

> *"Ensure a class has only one instance, and provide a global point of access to it."*  
> - Design Patterns: Elements of Reusable Object-Oriented Software

## Intent
Guarantee exactly one instance of a class and provide a well-known access point to it.

## Also Known As
Single instance.

## Motivation
A chocolate factory needs one controller for the chocolate boiler. If multiple controllers exist, the boiler can be filled, boiled, or drained out of order, which wastes ingredients and breaks safety rules.

## Chapter Summary (From the Book)
The chapter starts with a class that should exist only once in the system: the ChocolateBoiler. The naive approach uses a static accessor that lazily creates the instance, but the book shows how multiple threads can race and create more than one boiler.

The book explores synchronization as a fix, then refines it to reduce overhead with double-checked locking. It also points out that eager initialization is safe when the instance is always needed and that language features can make correct singletons easier to implement.

The core lesson: shared access is easy to code, but correct single-instance guarantees require careful construction, especially in multithreaded code.

## Applicability
- Use when exactly one object must coordinate system-wide behavior.
- Use when a global access point is required and must be controlled.
- Avoid when global state makes testing or dependency tracking difficult.

## Structure
```
+---------------------------+
|       ChocolateBoiler     |
|---------------------------|
| - ChocolateBoiler()       |
| + Boiler : ChocolateBoiler|
| + Fill()/Boil()/Drain()   |
+---------------------------+
```

## Participants
| Role | Class in This Project | Responsibility |
| --- | --- | --- |
| Singleton | `ChocolateBoiler` | Owns the single instance and exposes it through a static property. |
| Variant (not thread-safe) | `ChocolateBoilerNotThreadSafe` | Demonstrates the race condition risk. |
| Variant (double-checked) | `ChocolateBoilerThreadSafeLazy` | Adds locking to prevent multiple instances. |
| Variant (Lazy<T>) | `ChocolateBoilerLazyT` | Uses `Lazy<T>` for safe, lazy initialization. |
| Client | `Program` | Requests instances and exercises behavior. |

## Collaborations
`Program` requests the singleton instance and calls `Fill`, `Boil`, and `Drain`. The singleton guards creation so every caller operates on the same boiler object, even across threads when using the thread-safe variants.

## Consequences
- Controlled access ensures one shared resource, but it also creates global state.
- Thread safety requires extra care; naive lazy initialization can create multiple instances.
- Eager initialization is simple and fast but may create the instance even if it is never used.
- Singletons can hide dependencies and make tests harder if not isolated.

## Implementation Notes
- `ChocolateBoiler` uses eager initialization via a static property, which is thread-safe in .NET.
- `ChocolateBoilerThreadSafeLazy` demonstrates double-checked locking around instance creation.
- `ChocolateBoilerLazyT` uses `Lazy<T>` for the simplest correct lazy approach in C#.
- `ChocolateBoilerNotThreadSafe` is intentionally unsafe to show the race.

## Sample Code
```csharp
public sealed class Singleton
{
    private Singleton() { }
    private static readonly Singleton _instance = new Singleton();
    public static Singleton Instance => _instance;
}
```

## Known Uses
- `System.Runtime.Caching.MemoryCache.Default` exposes a shared cache instance.
- `System.Diagnostics.Trace` provides singleton-style access to tracing.
- ASP.NET Core DI `AddSingleton` registers a single shared service instance.

## Related Patterns
- Abstract Factory can be implemented as a singleton.
- Factory Method often uses a singleton creator.
- Builder may be a singleton when a single coordinator is required.

## Project File Map
```
Ch05_TheSingletonPattern/
  Ch05_TheSingletonPattern.csproj
  Program.cs
  Boilers/
    ChocolateBoiler.cs
    ChocolateBoilerLazyT.cs
    ChocolateBoilerNotThreadSafe.cs
    ChocolateBoilerThreadSafeLazy.cs
```

## How to Run
`dotnet run --project Ch05_TheSingletonPattern/Ch05_TheSingletonPattern.csproj`
