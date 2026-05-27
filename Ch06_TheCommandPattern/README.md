# Chapter 6 - Command Pattern

> *"Encapsulate a request as an object, thereby letting you parameterize clients with different requests, queue or log requests, and support undoable operations."*  
> - Design Patterns: Elements of Reusable Object-Oriented Software

## Intent
Turn a request into an object so requests can be stored, queued, logged, and undone independently of the invoker.

## Also Known As
Action, Transaction.

## Motivation
A universal remote must control many devices with different APIs. If the remote calls device methods directly, every new device or feature requires changes to the remote. Wrapping each request in a command object decouples the remote from the devices and makes undo and macros straightforward.

## Chapter Summary (From the Book)
The chapter begins with a remote control that knows too much about every vendor device. This tight coupling makes the remote hard to extend and impossible to undo. The book reframes each button press as a command object that can be stored, invoked, and reversed.

By introducing a common `ICommand` interface, the invoker becomes stable. New device actions are added by writing new command classes rather than modifying the remote. The chapter also extends the idea to undo and macro commands, demonstrating that once requests are objects, they can be composed and replayed.

## Applicability
- Use when an invoker should not know the details of the receiver.
- Use when requests need to be queued, logged, or undone.
- Use when you want to parameterize objects with actions.

## Structure
```
+-----------------------+     +------------------+
| RemoteControl (Invoker)| --> | ICommand         |
| + SetCommand()         |     | + Execute()      |
| + OnButtonWasPushed()  |     | + Undo()         |
+-----------------------+     +------------------+
                                   ^
                                   |
                    +------------------------------+
                    | Concrete Commands            |
                    | LightOnCommand, ...          |
                    +------------------------------+
                                   |
                                   v
                           +------------------+
                           | Receivers        |
                           | Light, Stereo... |
                           +------------------+
```

## Participants
| Role | Class in This Project | Responsibility |
| --- | --- | --- |
| Command | `ICommand` | Defines `Execute()` and `Undo()`. |
| Concrete Commands | `LightOnCommand`, `StereoOffCommand`, `CeilingFanHighCommand`, ... | Bind a receiver action to a request. |
| Invoker | `SimpleRemoteControl`, `RemoteControlWithUndo` | Stores commands and triggers them. |
| Receiver | `Light`, `CeilingFan`, `GarageDoor`, `Stereo` | Knows how to perform the real work. |
| Client | `Program` | Wires commands to slots. |

## Collaborations
`Program` creates receivers and wraps each action in a command. The invoker stores those commands and invokes them without knowing device details. Commands forward the request to their receiver and optionally remember state for undo.

## Consequences
- Decouples invokers from receivers, which makes the remote stable as new devices are added.
- Adds more classes, which increases the object count and maintenance overhead.
- Enables undo, logging, and scheduling because requests are first-class objects.
- Poorly designed commands can still hide dependencies if they capture too much context.

## Implementation Notes
- `NoCommand` is a Null Object used to avoid null checks for empty slots.
- `RemoteControlWithMultipleUndos` shows stack-based undo beyond the single-level undo.
- `CeilingFanCommandBase` uses a Template Method to share state capture logic.
- `MacroCommand` runs each command in order and undoes in the same order in this project.

## Sample Code
```csharp
public interface ICommand
{
    void Execute();
    void Undo();
}

public sealed class LightOnCommand : ICommand
{
    private readonly Light _light;
    public LightOnCommand(Light light) => _light = light;
    public void Execute() => _light.On();
    public void Undo() => _light.Off();
}
```

## Known Uses
- `System.Windows.Input.ICommand` in WPF and MAUI UI binding.
- `System.Data.Common.DbCommand` encapsulates a database request.
- Job queues and background services often store work as command objects.

## Related Patterns
- Composite can be used to build macro commands.
- Memento can capture state for multi-level undo.
- Template Method can share undo state logic across commands.

## Project File Map
```
Ch06_TheCommandPattern/
  Ch06_TheCommandPattern.csproj
  Program.cs
  Commands/
  Devices/
  Interfaces/
  RemoteControls/
```

## How to Run
`dotnet run --project Ch06_TheCommandPattern/Ch06_TheCommandPattern.csproj`
