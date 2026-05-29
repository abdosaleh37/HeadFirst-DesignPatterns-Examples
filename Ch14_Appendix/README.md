# Chapter 14 - Appendix: Leftover Patterns

> "This appendix groups the remaining GoF patterns into one runnable catalog."  
> - Head First Design Patterns (paraphrase)

## Intent
Provide concise demos for the remaining GoF patterns in one project.

## Also Known As
Appendix patterns.

## Motivation
Some patterns are shorter or more specialized than the main chapters. The appendix collects them in one place so you can compare their roles side by side.

## Chapter Summary (From the Book)
The appendix completes the GoF catalog by offering short, focused examples. The goal is recognition and comparison rather than deep domain stories.

## Applicability
- Use when you want a quick reference for lesser-used patterns.
- Use to compare patterns that solve different forces with small examples.

## Structure
```
Bridge + Builder + Chain + Flyweight + Interpreter + Mediator + Memento + Prototype + Visitor
```

## Participants
| Pattern | Demo Entry Point | Responsibility |
| --- | --- | --- |
| Bridge | `BridgeDemo.Run()` | Separates abstraction and implementation. |
| Builder | `BuilderDemo.Run()` | Builds complex objects step by step. |
| Chain of Responsibility | `ChainDemo.Run()` | Routes requests through handlers. |
| Flyweight | `FlyweightDemo.Run()` | Shares intrinsic state. |
| Interpreter | `InterpreterDemo.Run()` | Evaluates expression trees. |
| Mediator | `MediatorDemo.Run()` | Centralizes collaboration. |
| Memento | `MementoDemo.Run()` | Captures and restores snapshots. |
| Prototype | `PrototypeDemo.Run()` | Clones existing objects. |
| Visitor | `VisitorDemo.Run()` | Adds operations via double dispatch. |

## Collaborations
Each demo is independent. The appendix is a catalog rather than a single composed system.

## Consequences
- Easy side-by-side comparison of patterns.
- Less narrative context than earlier chapters.
- Demos are intentionally small and focus on intent.

## Implementation Notes
- Each pattern has its own folder and `*Demo.Run()` entry point.
- `Program.cs` prints a labeled header before each demo.

## Sample Code
```csharp
BridgeDemo.Run();
BuilderDemo.Run();
ChainDemo.Run();
```

## Known Uses
- Many UI, framework, and tooling libraries rely on these patterns in specific contexts.

## Related Patterns
- Several appendix patterns complement earlier chapters (for example, Chain with Command, Visitor with Composite).

## Project File Map
```
Ch14_Appendix/
	Ch14_Appendix.csproj
	Program.cs
	Bridge/
	Builder/
	ChainOfResponsibility/
	Flyweight/
	Interpreter/
	Mediator/
	Memento/
	Prototype/
	Visitor/
```

## How to Run
`dotnet run --project Ch14_Appendix/Ch14_Appendix.csproj`
