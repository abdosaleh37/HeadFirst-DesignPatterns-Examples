# Chapter 7 (Part I): The Adapter Pattern

## Pattern Definition

**The Adapter Pattern** converts the interface of a class into another interface that clients expect. Adapter lets classes work together that couldn't otherwise because of incompatible interfaces.

## The Problem

You have an existing system built around the `Duck` interface, but you want to plug in a `Turkey` object. The interfaces are incompatible:

| Duck | Turkey |
|------|--------|
| `Quack()` | `Gobble()` |
| `Fly()` (long distance) | `Fly()` (short distance) |

You can't use a `Turkey` where a `Duck` is expected — **unless you adapt it!**

**Without an adapter:**

```csharp
Duck duck = new MallardDuck();
// This won't compile — Turkey is not a Duck!
Duck turkey = new WildTurkey();
```

## The Solution: Adapter Pattern

An **Adapter** sits between your client code and the incompatible interface. It wraps the adaptee and exposes the target interface the client expects.

### Key Metaphor: The Travel Adapter

Think of a European power plug and a US outlet:

- **Client** = Device needing power
- **US Outlet** = Target interface (`Duck`)
- **European Plug** = Adaptee (`Turkey`)
- **Travel Adapter** = The Adapter (`TurkeyAdapter`)

The travel adapter converts the European plug to fit the US outlet — without modifying either!

## Design Principles Applied

### 1. **Favor Composition over Inheritance**

The adapter *wraps* the adaptee using composition, rather than inheriting from it:

```csharp
public class TurkeyAdapter : Duck
{
    private readonly Turkey _turkey;  // Composition!

    public TurkeyAdapter(Turkey turkey) => _turkey = turkey;
}
```

### 2. **Program to an Interface**

Client code depends only on the `Duck` interface — it never knows it's talking to a Turkey underneath.

### 3. **Open/Closed Principle**

New adaptees can be added without modifying existing client code.

## Class Diagram

```
                        ┌──────────────────┐
                        │  <<interface>>   │
                        │      Duck        │
                        ├──────────────────┤
                        │ + Quack()        │
                        │ + Fly()          │
                        └──────────────────┘
                                 ▲
               ┌─────────────────┴─────────────────┐
               │                                   │
   ┌───────────────────┐               ┌───────────────────┐
   │    MallardDuck    │               │   TurkeyAdapter   │
   ├───────────────────┤               ├───────────────────┤
   │ + Quack()         │               │ - _turkey         │──► Turkey
   │ + Fly()           │               │ + Quack()         │
   └───────────────────┘               │ + Fly()           │
                                       └───────────────────┘

                        ┌──────────────────┐
                        │  <<interface>>   │
                        │     Turkey       │
                        ├──────────────────┤
                        │ + Gobble()       │
                        │ + Fly()          │
                        └──────────────────┘
                                 ▲
               ┌─────────────────┴─────────────────┐
               │                                   │
   ┌───────────────────┐               ┌───────────────────┐
   │    WildTurkey     │               │    DuckAdapter    │
   ├───────────────────┤               ├───────────────────┤
   │ + Gobble()        │               │ - _duck           │──► Duck
   │ + Fly()           │               │ + Gobble()        │
   └───────────────────┘               │ + Fly()           │
                                       └───────────────────┘
```

## Implementation Details

### 1. Target Interface (`Duck`)

```csharp
public interface Duck
{
    void Quack();
    void Fly();
}
```

### 2. Adaptee Interface (`Turkey`)

```csharp
public interface Turkey
{
    void Gobble();
    void Fly();
}
```

### 3. Object Adapter — Turkey adapted to Duck (`TurkeyAdapter`)

```csharp
public class TurkeyAdapter : Duck
{
    private readonly Turkey _turkey;

    public TurkeyAdapter(Turkey turkey) => _turkey = turkey;

    public void Quack() => _turkey.Gobble();  // Translate Quack → Gobble

    public void Fly()
    {
        for (int i = 0; i < 5; i++)   // Turkey flies short, so call 5 times
            _turkey.Fly();
    }
}
```

**Key Points:**

- Implements the target interface (`Duck`)
- Holds a reference to the adaptee (`Turkey`) — composition
- Translates each call: `Quack()` → `Gobble()`, `Fly()` → five short `Fly()` calls

### 4. Reverse Adapter — Duck adapted to Turkey (`DuckAdapter`)

```csharp
public class DuckAdapter : Turkey
{
    private readonly Duck _duck;
    private readonly Random _random;

    public DuckAdapter(Duck duck)
    {
        _duck = duck;
        _random = new Random();
    }

    public void Gobble() => _duck.Quack();  // Translate Gobble → Quack

    public void Fly()
    {
        if (_random.Next(5) == 0)   // Ducks don't gobble as often
            _duck.Fly();
    }
}
```

---

## Enumeration to Iterator Adapter

The book also demonstrates adapting a **legacy interface** to a **modern interface** — a real-world scenario when migrating older codebases.

### The Problem

An older codebase exposes data through a custom `IEnumeration<T>` interface (inspired by Java's legacy `Enumeration`). Modern C# code expects `IEnumerator<T>`, which is compatible with `foreach`. The two interfaces look different:

```
IEnumeration<T>               IEnumerator<T>
───────────────               ──────────────
HasMoreElements()    →        MoveNext()
NextElement()        →        Current
(no reset support)   →        Reset() → throws NotSupportedException
```

### Legacy Interface (`IEnumeration<T>`)

```csharp
public interface IEnumeration<T>
{
    bool HasMoreElements();
    T NextElement();
}
```

### Adapter (`EnumerationIterator<T>`)

```csharp
public class EnumerationIterator<T> : IEnumerator<T>
{
    private readonly IEnumeration<T> _enumeration;
    private T _current = default!;

    public EnumerationIterator(IEnumeration<T> enumeration) => _enumeration = enumeration;

    public T Current => _current;

    public bool MoveNext()
    {
        if (_enumeration.HasMoreElements())
        {
            _current = _enumeration.NextElement();
            return true;
        }
        return false;
    }

    public void Reset() => throw new NotSupportedException("Enumeration does not support Reset.");

    public void Dispose() { }
}
```

**Key Points:**

- Implements the target interface (`IEnumerator<T>`)
- Wraps the legacy `IEnumeration<T>` via composition
- `MoveNext()` maps to `HasMoreElements()` + `NextElement()`
- `Reset()` throws `NotSupportedException` — there is no equivalent in the old interface

### Usage

```csharp
IEnumeration<string> enumeration = new ListEnumeration<string>(names);
IEnumerator<string> iterator = new EnumerationIterator<string>(enumeration);

while (iterator.MoveNext())
    Console.WriteLine(iterator.Current);
```

---

## Two Types of Adapters

### Object Adapter (used here)

- Wraps the adaptee using **composition**
- Can adapt a class **and all its subclasses**
- More flexible — preferred in C#

### Class Adapter

- Uses **multiple inheritance** to inherit from both target and adaptee
- Not available in C# (single inheritance only)
- Common in C++ and other languages that support multiple inheritance

---

## Real-World Applications

- **Legacy system integration** — wrapping old APIs to work with new code
- **.NET `IEnumerable<T>`** — many collection types adapt to this interface
- **Database drivers** — ADO.NET adapts different databases to a common interface
- **UI frameworks** — adapting data models to UI controls (e.g., `DataAdapter` in WinForms)
- **Third-party libraries** — adapting an external API to your own internal interfaces

---

## Key Takeaways

1. **Adapter = Translator** — converts one interface into another without changing either side
2. **Composition over Inheritance** — wraps the adaptee, doesn't extend it
3. **Decouples client from adaptee** — client never knows what's inside the adapter
4. **Two-way adapters** — you can adapt in both directions (TurkeyAdapter + DuckAdapter)
5. **Legacy migration** — powerful for gradually updating old interfaces to modern ones

---

## Demo Output

```
The Turkey says...
Gobble gobble
I'm flying a short distance

The Duck says...
Quack
I'm flying

The TurkeyAdapter says...
Gobble gobble
I'm flying a short distance
I'm flying a short distance
I'm flying a short distance
I'm flying a short distance
I'm flying a short distance

The DuckAdapter says...
Quack
(Fly output may vary — triggered randomly)

--- Enumeration to Iterator Adapter Demo ---
Iterating over names using EnumerationIterator:
Alice
Bob
Charlie
Dave
```

---

**"Convert the interface of a class into another interface clients expect. Adapter lets classes work together that couldn't otherwise because of incompatible interfaces."**
