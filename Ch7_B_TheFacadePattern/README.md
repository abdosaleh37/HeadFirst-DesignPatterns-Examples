# Chapter 7 (Part II): The Facade Pattern

## Pattern Definition

**The Facade Pattern** provides a simplified interface to a complex subsystem of classes, libraries, or frameworks.

## The Problem

Watching a movie involves coordinating **seven separate subsystems**, each with its own complex API:

```csharp
// Without a Facade — the client has to manage everything manually!
popper.On();
popper.Pop();
lights.Dim(10);
screen.Down();
projector.On();
projector.WideScreenMode();
amp.On();
amp.SetStreamingPlayer(player);
amp.SetSurroundSound();
amp.SetVolume(5);
player.On();
player.Play("Raiders of the Lost Ark");
```

**Problems with no facade:**

1. **Complexity** — client must know how all subsystems work and interact
2. **Tight coupling** — client depends directly on 7 component classes
3. **Error-prone** — easy to miss a step or call methods in the wrong order
4. **Hard to change** — updating any subsystem can break the client
5. **Not user-friendly** — too many details for a simple "watch movie" action

## The Solution: Facade Pattern

A **Facade** wraps the subsystem in a simple, unified interface. The client calls one method and the facade handles all the complexity.

```csharp
// With a Facade — one simple call!
homeTheater.WatchMovie("Raiders of the Lost Ark");
```

## Design Principle: Principle of Least Knowledge

> *Talk only to your immediate friends.*

Also known as the **Law of Demeter** — a component should only call methods on:

1. The object itself
2. Objects passed in as parameters
3. Objects it creates or instantiates
4. Its own component objects (fields)

The Facade enforces this by giving clients a single, simple friend to talk to instead of the entire subsystem.

## Class Diagram

```
                    ┌───────────────────────────────┐
                    │      HomeTheaterFacade        │
                    ├───────────────────────────────┤
        Client ───► │ + WatchMovie(movie)           │
                    │ + EndMovie()                  │
                    │ + ListenToRadio(frequency)    │
                    │ + EndRadio()                  │
                    └───────────────────────────────┘
                                   │
          ┌──────────┬─────────────┼────────────┬──────────┬──────────┐
          │          │             │            │          │          │
          ▼          ▼             ▼            ▼          ▼          ▼
   ┌──────────┐ ┌────────┐ ┌───────────┐ ┌─────────┐ ┌────────┐ ┌─────────┐
   │Amplifier │ │ Tuner  │ │ Streaming │ │Projector│ │Theater │ │ Screen  │
   │          │ │        │ │  Player   │ │         │ │ Lights │ │         │
   └──────────┘ └────────┘ └───────────┘ └─────────┘ └────────┘ └─────────┘
                                                             ┌─────────────┐
                                                             │  Popcorn    │
                                                             │   Popper    │
                                                             └─────────────┘
```

## Implementation Details

### Key Components

#### 1. The Facade (`HomeTheaterFacade`)

```csharp
public class HomeTheaterFacade
{
    // References to all subsystem components
    private readonly Amplifier _amplifier;
    private readonly Tuner _tuner;
    private readonly StreamingPlayer _player;
    private readonly Projector _projector;
    private readonly TheaterLights _lights;
    private readonly Screen _screen;
    private readonly PopcornPopper _popper;

    public void WatchMovie(string movie)
    {
        Console.WriteLine("Get ready to watch a movie...");
        _popper.On();
        _popper.Pop();
        _lights.Dim(10);
        _screen.Down();
        _projector.On();
        _projector.WideScreenMode();
        _amplifier.On();
        _amplifier.SetStreamingPlayer(_player);
        _amplifier.SetSurroundSound();
        _amplifier.SetVolume(5);
        _player.On();
        _player.Play(movie);
    }

    public void EndMovie() { /* reverse of WatchMovie */ }
    public void ListenToRadio(double frequency) { /* tune to radio */ }
    public void EndRadio() { /* shut down tuner */ }
}
```

**Key Points:**

- Holds references to all subsystem components (injected via constructor)
- Each high-level method orchestrates multiple subsystem calls in the correct order
- Subsystem classes are still accessible directly if needed — the facade doesn't lock you out

#### 2. Subsystem Components (examples)

**Amplifier:**

```csharp
public class Amplifier
{
    public void On() => Console.WriteLine("Top-O-Line Amplifier on");
    public void Off() => Console.WriteLine("Top-O-Line Amplifier off");
    public void SetStreamingPlayer(StreamingPlayer player) { ... }
    public void SetSurroundSound() => Console.WriteLine("...(5 speakers, 1 subwoofer)");
    public void SetVolume(int level) => Console.WriteLine($"...setting volume to {level}");
    public void SetTuner(Tuner tuner) { ... }
}
```

**StreamingPlayer:**

```csharp
public class StreamingPlayer
{
    public void On() => Console.WriteLine("Top-O-Line Streaming Player on");
    public void Play(string movie) => Console.WriteLine($"...playing \"{movie}\"");
    public void Stop() => Console.WriteLine($"...stopped \"{_movie}\"");
    public void Off() => Console.WriteLine("Top-O-Line Streaming Player off");
}
```

#### 3. Client Code (`Program.cs`)

```csharp
// Wire up the subsystem
Amplifier amp = new Amplifier();
Tuner tuner = new Tuner(amp);
StreamingPlayer player = new StreamingPlayer(amp);
Projector projector = new Projector(player);
TheaterLights lights = new TheaterLights();
Screen screen = new Screen();
PopcornPopper popper = new PopcornPopper();

// Create the facade
HomeTheaterFacade homeTheater = new HomeTheaterFacade(
    amp, tuner, player, projector, lights, screen, popper);

// Use the simple facade API
homeTheater.WatchMovie("Raiders of the Lost Ark");
homeTheater.EndMovie();
homeTheater.ListenToRadio(88.1);
homeTheater.EndRadio();
```

---

## Facade vs. Other Patterns

| Pattern | Intent |
|---------|--------|
| **Facade** | Provides a *simplified* interface to a complex subsystem |
| **Adapter** | *Converts* one interface to another |
| **Decorator** | *Adds* responsibilities to an interface without changing it |
| **Proxy** | *Controls access* to an object |

The Facade doesn't hide the subsystem — you can still use the subsystem directly if you need full control.

---

## Benefits of the Facade Pattern

1. **Simplicity** — one friendly interface instead of dozens of classes
2. **Loose coupling** — client depends only on the facade, not on 7 subsystems
3. **Organized complexity** — subsystems can still be used directly when needed
4. **Easier to use** — common tasks become one-liners
5. **Easier to maintain** — subsystem internals can change without affecting clients

---

## Real-World Applications

- **`Console`** in .NET — facades over OS-level I/O streams
- **`File.ReadAllText()`** — facades over `FileStream`, `StreamReader`, buffer management
- **ORMs (Entity Framework)** — facade over SQL, connections, transactions, change tracking
- **Web frameworks** — `HttpContext` facades over request/response pipeline
- **SDK wrappers** — cloud SDK clients (Azure, AWS) wrap complex REST APIs

---

## Key Takeaways

1. **Facade = Simplicity** — wraps complexity behind a clean, easy-to-use interface
2. **Doesn't lock you out** — subsystem classes are still accessible for power users
3. **Principle of Least Knowledge** — clients talk to the facade, not the entire subsystem
4. **Great for layered architectures** — each layer can expose a facade to the layer above
5. **Multiple facades** — you can create multiple facades for the same subsystem for different use cases

---

## Demo Output

```
Get ready to watch a movie...
Popcorn Popper on
Popcorn Popper popping popcorn!
Theater Ceiling Lights dimming to 10%
Theater Screen going down
Top-O-Line Projector on
Top-O-Line Projector in widescreen mode (16x9 aspect ratio)
Top-O-Line Amplifier on
Top-O-Line Amplifier setting Streaming player to Top-O-Line Streaming Player
Top-O-Line Amplifier surround sound on (5 speakers, 1 subwoofer)
Top-O-Line Amplifier setting volume to 5
Top-O-Line Streaming Player on
Top-O-Line Streaming Player playing "Raiders of the Lost Ark"

Shutting movie theater down...
Popcorn Popper off
Theater Ceiling Lights on
Theater Screen going up
Top-O-Line Projector off
Top-O-Line Amplifier off
Top-O-Line Streaming Player stopped "Raiders of the Lost Ark"
Top-O-Line Streaming Player off

Tuning in the airwaves...
AM/FM Tuner on
AM/FM Tuner setting frequency to 88.1
Top-O-Line Amplifier on
Top-O-Line Amplifier setting volume to 5
Top-O-Line Amplifier setting tuner to AM/FM Tuner

Shutting down the tuner...
AM/FM Tuner off
Top-O-Line Amplifier off
```

---

**"Provide a unified interface to a set of interfaces in a subsystem. Facade defines a higher-level interface that makes the subsystem easier to use."**
