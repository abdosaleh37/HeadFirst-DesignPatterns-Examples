# Chapter 7B - Facade Pattern

> "Provide a unified interface to a set of interfaces in a subsystem. Facade defines a higher-level interface that makes the subsystem easier to use."  
> - Design Patterns: Elements of Reusable Object-Oriented Software

## Intent
Offer a simple, high-level API for a complex subsystem.

## Also Known As
N/A.

## Motivation
A home theater requires coordinated calls across many devices: amplifier, projector, screen, lights, and more. A facade provides one easy method like `WatchMovie()` while hiding the choreography.

## Chapter Summary (From the Book)
The chapter shows a subsystem with many classes that work well together but are awkward for clients to control. The client must know the correct ordering and configuration for every device.

By introducing a facade, the client code shrinks to a few high-level calls. The subsystem remains available for advanced use, but most users can rely on the simplified interface and the Principle of Least Knowledge.

## Applicability
- Use when you need a simple entry point to a complex subsystem.
- Use to reduce coupling between clients and subsystem classes.
- Use to organize layers so each layer exposes a minimal interface to the next.

## Structure
```
+-------------------------+     +------------------+
| HomeTheaterFacade       | --> | Subsystem        |
| + WatchMovie()          |     | Amplifier, ...   |
| + EndMovie()            |     +------------------+
| + ListenToRadio()       |
| + EndRadio()            |
+-------------------------+
```

## Participants
| Role | Class in This Project | Responsibility |
| --- | --- | --- |
| Facade | `HomeTheaterFacade` | Provides high-level operations. |
| Subsystem | `Amplifier`, `Projector`, `StreamingPlayer`, `Screen`, `TheaterLights`, `PopcornPopper`, `Tuner` | Implements detailed device behavior. |
| Client | `Program` | Uses the facade for common tasks. |

## Collaborations
The client calls a facade method like `WatchMovie()`. The facade orchestrates the subsystem calls in the correct order while keeping the client unaware of the details.

## Consequences
- Simplifies use of a complex subsystem.
- Reduces coupling between clients and subsystem classes.
- Adds an extra layer that must be kept in sync with subsystem changes.
- Does not prevent direct subsystem access when needed.

## Implementation Notes
- `HomeTheaterFacade` holds references to each subsystem component.
- Each high-level method sequences device calls to avoid incorrect orderings.
- The subsystem remains public for advanced scenarios.

## Sample Code
```csharp
public sealed class HomeTheaterFacade
{
    private readonly Amplifier _amp;
    private readonly StreamingPlayer _player;

    public HomeTheaterFacade(Amplifier amp, StreamingPlayer player)
    {
        _amp = amp;
        _player = player;
    }

    public void WatchMovie(string movie)
    {
        _amp.On();
        _player.On();
        _player.Play(movie);
    }
}
```

## Known Uses
- `Console` provides a facade over console I/O streams.
- `File.ReadAllText()` wraps file streams, buffers, and encodings.
- ORM APIs like Entity Framework provide a facade over connections and SQL commands.

## Related Patterns
- Adapter translates interfaces; Facade simplifies them.
- Decorator adds behavior without changing the interface.
- Proxy controls access while keeping the same interface.

## Project File Map
```
Ch07B_TheFacadePattern/
  Ch07B_TheFacadePattern.csproj
  Program.cs
  Components/
  Facades/
```

## How to Run
`dotnet run --project Ch07B_TheFacadePattern/Ch07B_TheFacadePattern.csproj`
