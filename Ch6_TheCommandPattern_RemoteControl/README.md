# Chapter 6: The Command Pattern - Remote Control

## Pattern Definition

**The Command Pattern** encapsulates a request as an object, thereby letting you parameterize clients with different requests, queue or log requests, and support undoable operations.

## The Problem

You've been hired to create an API for a home automation remote control. The remote has:

- 7 programmable slots (each with ON and OFF buttons)
- An UNDO button
- Controls for various vendors' devices (lights, fans, stereos, garage doors, etc.)

**Initial Approach (The Wrong Way):**

```csharp
public class RemoteControl
{
    public void Slot1On()
    {
        light.TurnOn();  // Directly calling device methods - PROBLEMS!
    }
    
    public void Slot1Off()
    {
        light.TurnOff();
    }
    
    public void Slot2On()
    {
        stereo.PowerOn();
        stereo.SetCD();
        stereo.SetVolume(11);
    }
    // Different vendors, different APIs!
}
```

**Problems with direct method calls:**

1. **Tight coupling** - Remote knows about all concrete device classes
2. **Not extensible** - Can't add new devices without modifying remote
3. **No undo support** - Can't track/reverse operations
4. **Vendor dependent** - Each vendor has different method names
5. **Can't queue/log requests** - Actions are executed immediately
6. **Violates Open/Closed Principle** - Remote must change for every new device

## The Solution: Command Pattern

**Design Principle:** *Encapsulate what varies.* In this case, the requests/actions vary!

The Command Pattern allows you to decouple the object that invokes the operation from the one that knows how to perform it.

### How It Works

1. **Create a Command interface** with `Execute()` and `Undo()` methods
2. **Implement concrete commands** for each action (LightOnCommand, StereoOnCommand, etc.)
3. **Commands encapsulate device actions** - they hold a reference to the device
4. **Remote stores commands** in slots, not devices
5. **Remote invokes commands** without knowing what they do
6. **Commands can be undone** by implementing `Undo()`

### Key Metaphor: The Diner

Think of a diner:

- **Customer** = Client (creates command)
- **Waitress** = Invoker (stores and executes commands)
- **Order** = Command Object (encapsulates request)
- **Cook** = Receiver (knows how to prepare the food)

The waitress doesn't need to know how to cook! She just takes orders and calls `orderUp()`.

## Design Principles Applied

### 1. **Encapsulate What Varies**

- Requests are encapsulated as command objects
- New requests don't require changing the invoker (remote)

### 2. **Program to an Interface**

```csharp
public ICommand OnCommands[7];  // Not concrete command classes!
```

### 3. **Loose Coupling**

- Remote doesn't know about concrete devices or commands
- Commands don't know about the remote
- Devices don't know about commands

### 4. **Single Responsibility Principle**

- Remote: manages and invokes commands
- Commands: encapsulate requests
- Devices: perform actual work

## Class Diagram

```
┌─────────────────────────┐
│   RemoteControl         │
│     (Invoker)           │
├─────────────────────────┤
│ - onCommands[]          │────────┐
│ - offCommands[]         │        │
│ - undoCommand           │        │
├─────────────────────────┤        │
│ + SetCommand()          │        │
│ + OnButtonWasPushed()   │        │
│ + OffButtonWasPushed()  │        │
│ + UndoButtonWasPushed() │        │
└─────────────────────────┘        │
                                   │ holds
                                   ▼
                         ┌─────────────────┐
                         │   <<interface>> │
                         │    ICommand     │
                         ├─────────────────┤
                         │ + Execute()     │
                         │ + Undo()        │
                         └─────────────────┘
                                   ▲
                                   │ implements
          ┌────────────┬───────────┼────────────┬─────────────┐
          │            │           │            │             │
   ┌──────┴──────┐  ┌──┴────┐ ┌────┴──────┐ ┌───┴────┐  ┌─────┴─────┐
   │   LightOn   │  │ Light │ │ CeilingFan│ │Garage  │  │   Macro   │
   │   Command   │  │ Off   │ │   High    │ │ Door   │  │  Command  │
   └─────────────┘  │Command│ │  Command  │ │  Up    │  └───────────┘
          │         └───────┘ └───────────┘ │Command │        │
          │                         │       └────────┘        │
          │ calls                   │ calls      │ calls      │ calls
          ▼                         ▼            ▼            ▼
   ┌─────────────┐         ┌──────────────┐  ┌──────────┐   [Multiple
   │    Light    │         │  CeilingFan  │  │ Garage   │   Commands]
   │  (Receiver) │         │  (Receiver)  │  │  Door    │
   ├─────────────┤         ├──────────────┤  │(Receiver)│
   │ + On()      │         │ + High()     │  ├──────────┤
   │ + Off()     │         │ + Medium()   │  │ + Up()   │
   └─────────────┘         │ + Low()      │  │ + Down() │
                           │ + Off()      │  └──────────┘
                           └──────────────┘
```

## Implementation Details

### Key Components

#### 1. Command Interface

```csharp
public interface ICommand
{
    void Execute();  // Perform the action
    void Undo();     // Reverse the action
}
```

#### 2. Concrete Command (Example: LightOnCommand)

```csharp
public class LightOnCommand : ICommand
{
    private readonly Light _light;  // Receiver

    public LightOnCommand(Light light) => _light = light;

    public void Execute() => _light.On();    // Delegate to receiver
    public void Undo() => _light.Off();      // Reverse the action
}
```

**Key Points:**

- Command holds a reference to the receiver (Light)
- `Execute()` calls the appropriate method on the receiver
- `Undo()` reverses the action

#### 3. Receiver (Example: Light)

```csharp
public class Light
{
    private string _location;

    public Light(string location) => _location = location;

    public void On() => Console.WriteLine($"{_location} light is ON");
    public void Off() => Console.WriteLine($"{_location} light is OFF");
}
```

**Key Points:**

- Knows how to perform the actual work
- No knowledge of commands or remote

#### 4. Invoker (RemoteControl)

```csharp
public class RemoteControl
{
    public List<ICommand> OnCommands { get; }
    public List<ICommand> OffCommands { get; }

    public void SetCommand(int slot, ICommand onCommand, ICommand offCommand)
    {
        OnCommands[slot] = onCommand;
        OffCommands[slot] = offCommand;
    }

    public void OnButtonWasPushed(int slot)
    {
        OnCommands[slot].Execute();  // Invoke command
    }

    public void OffButtonWasPushed(int slot)
    {
        OffCommands[slot].Execute();  // Invoke command
    }
}
```

**Key Points:**

- Stores commands in slots
- Doesn't know what commands do
- Simply calls `Execute()` when button is pushed

#### 5. NoCommand (Null Object Pattern)

```csharp
public class NoCommand : ICommand
{
    public void Execute() { }  // Do nothing
    public void Undo() { }     // Do nothing
}
```

**Key Points:**

- Eliminates need for null checks
- Provides a "do nothing" behavior
- Makes code cleaner and safer

## Advanced Features

### 1. **Undo Support**

Commands track previous state to support undo:

```csharp
public class CeilingFanHighCommand : ICommand
{
    private CeilingFanSpeed previousSpeed;

    public void Execute()
    {
        previousSpeed = _ceilingFan.Speed;  // Save state
        _ceilingFan.High();
    }

    public void Undo()
    {
        RestoreSpeed(previousSpeed);  // Restore previous state
    }
}
```

### 2. **Multiple Undo (Stack-based)**

```csharp
public Stack<ICommand> UndoCommands { get; }

public void OnButtonWasPushed(int slot)
{
    OnCommands[slot].Execute();
    UndoCommands.Push(OnCommands[slot]);  // Push to stack
}

public void UndoButtonWasPushed()
{
    if (UndoCommands.Count > 0)
    {
        ICommand command = UndoCommands.Pop();
        command.Undo();
    }
}
```

### 3. **Macro Commands**

Execute multiple commands as one:

```csharp
public class MacroCommand : ICommand
{
    private readonly ICommand[] _commands;

    public MacroCommand(ICommand[] commands) => _commands = commands;

    public void Execute()
    {
        foreach (var command in _commands)
            command.Execute();
    }

    public void Undo()
    {
        for (int i = _commands.Length - 1; i >= 0; i--)
            _commands[i].Undo();
    }
}

// Usage: Party Mode!
var partyOn = new MacroCommand([
    new LightOnCommand(light),
    new StereoOnCommand(stereo),
    new CeilingFanMediumCommand(fan)
]);
```

## Benefits of the Command Pattern

1. **Decouples invoker from receiver** - Remote doesn't know about devices
2. **Extensible** - Add new commands without changing remote
3. **Undo/Redo support** - Commands can store and restore state
4. **Macro commands** - Combine multiple commands
5. **Queueing requests** - Commands can be stored and executed later
6. **Logging requests** - Commands can be logged for replay
7. **Transactional behavior** - All-or-nothing execution

## Real-World Applications

- **GUI buttons/menus** - Each button/menu item has a command
- **Thread pools/job queues** - Commands represent jobs
- **Transactional systems** - Commands represent transactions
- **Macro recording** - Record and replay user actions
- **Network requests** - Commands represent remote procedure calls
- **Game input** - Commands represent player actions

## Design Patterns Relationship

- **Command + Composite** = Macro Commands
- **Command + Memento** = Advanced undo with full state snapshots
- **Command + Strategy** = Both encapsulate algorithms, but Command adds undo/queueing
- **Command + Template Method** = CeilingFanCommandBase uses Template Method

## Key Takeaways

1. **Command = Encapsulated Request** - An object that represents an action
2. **Separation of Concerns** - Invoker, Command, and Receiver have distinct roles
3. **Flexibility** - Commands can be passed, stored, queued, and executed at any time
4. **Undo/Redo** - Commands track state changes for reversible operations
5. **Null Object Pattern** - NoCommand eliminates null checks

## Demo Output

The program demonstrates:

1. **Simple Remote** - One button, one command
2. **Standard Remote** - Multiple slots, ON/OFF buttons
3. **Remote with Undo** - Single undo command
4. **Remote with Multiple Undos** - Stack-based undo history
5. **Macro Commands** - Party mode (multiple commands at once)

Run the program to see all features in action!

---

**"Encapsulate requests as objects to decouple senders from receivers, enabling flexible, undoable, and reusable operations."**
