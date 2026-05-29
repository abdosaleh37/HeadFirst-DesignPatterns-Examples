# Chapter 11 - Proxy Pattern

> "Provide a surrogate or placeholder for another object to control access to it."  
> - Design Patterns: Elements of Reusable Object-Oriented Software

## Intent
Control access to a subject by placing a proxy in front of it while keeping the same interface.

## Also Known As
Surrogate.

## Motivation
Clients should interact with a gumball machine monitor without caring whether the machine is local or remote. The same idea applies to lazy-loading images and enforcing permissions on profile updates.

## Chapter Summary (From the Book)
The book uses remote proxies (Java RMI), virtual proxies, and protection proxies to show how a placeholder object can manage access while keeping clients simple.

This C# version mirrors the intent with a Minimal API and `HttpClient` for the remote proxy, plus explicit virtual and protection proxies for lazy loading and access control.

## Applicability
- Use when you need to control access to a resource without changing clients.
- Use to defer expensive creation until it is actually needed.
- Use to enforce permissions or boundaries around a sensitive object.

## Structure
```
Client -> Subject -> (Proxy) -> RealSubject
```

## Participants
| Role | Class in This Project | Responsibility |
| --- | --- | --- |
| Subject | `IGumballMachineRemote`, `IIcon`, `IPersonBean` | Common interface used by clients. |
| Real Subject | `GumballMachineService`, `ImageIcon`, `PersonBean` | Performs the real work. |
| Proxy | `GumballMachineProxy`, `ImageProxy`, `OwnerPersonProxy`, `NonOwnerPersonProxy` | Controls access or creation. |
| Client | `GumballMonitor`, `Program` | Uses the subject interface without knowing the real subject. |

## Collaborations
Clients talk to the proxy using the subject interface. The proxy forwards calls, defers creation, or blocks operations depending on the proxy type.

## Consequences
- Keeps client code simple and decoupled from access details.
- Adds another layer that must be implemented and maintained.
- Can hide network or lazy-load failures until runtime.

## Implementation Notes
- The remote proxy uses a local Minimal API host and `HttpClient` as a stand-in for RMI.
- The virtual proxy creates `ImageIcon` only when `Render()` is called.
- Protection proxies throw `InvalidOperationException` for forbidden operations.

## Sample Code
```csharp
public interface IIcon
{
    string Render();
}

public sealed class ImageProxy : IIcon
{
    private ImageIcon? _realIcon;

    public string Render()
    {
        _realIcon ??= new ImageIcon("https://example.com/album-cover.jpg");
        return _realIcon.Render();
    }
}
```

## Known Uses
- Lazy-loading proxies in ORMs.
- Network stubs that hide remote calls.
- Permission wrappers that enforce access rules.

## Related Patterns
- Adapter translates interfaces; Proxy keeps the same interface.
- Decorator adds behavior without controlling access.
- Facade simplifies a subsystem without representing a specific subject.

## Project File Map
```
Ch11_TheProxyPattern/
  Ch11_TheProxyPattern.csproj
  Program.cs
  Interfaces/
  Models/
  Proxies/
```

## How to Run
`dotnet run --project Ch11_TheProxyPattern/Ch11_TheProxyPattern.csproj`
