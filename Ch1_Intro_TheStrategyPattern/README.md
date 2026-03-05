# Chapter 1: Introduction to Design Patterns - The Strategy Pattern

## Pattern Definition

**The Strategy Pattern** defines a family of algorithms, encapsulates each one, and makes them interchangeable. Strategy lets the algorithm vary independently from clients that use it.

## The Problem

Imagine you're building a duck simulator game. You start with a simple `Duck` superclass from which all ducks inherit.

**Initial Approach (The Wrong Way):**

```csharp
public class Duck
{
    public void Quack() { ... }
    public void Swim() { ... }
    public void Display() { ... }  // Abstract - each duck looks different
    public void Fly() { ... }      // NEW requirement!
}
```

**Problems with inheritance:**

1. **Not all ducks fly!** (RubberDuck, DecoyDuck don't fly)
2. **Not all ducks quack!** (RubberDuck squeaks, DecoyDuck is silent)
3. **Code duplication** across duck types
4. **Hard to maintain** - changing flying behavior affects ALL ducks
5. **Runtime behavior changes** are impossible

**Why interfaces don't solve it:**

```csharp
interface IFlyable { void Fly(); }
interface IQuackable { void Quack(); }
```

- Still leads to **code duplication** in every duck class
- **No code reuse** - violates DRY principle
- **Maintenance nightmare** - change behavior = change all classes

## The Solution: Strategy Pattern

**Design Principle:** *Identify the aspects of your application that vary and separate them from what stays the same.*

**Key Insight:** Take behaviors (flying, quacking) that vary and **pull them out** into separate classes!

### How It Works

1. **Identify varying behaviors**: Flying and Quacking
2. **Create behavior interfaces**:
   - `IFlyBehavior` - defines flying behavior
   - `IQuackBehavior` - defines quacking behavior
3. **Implement concrete behaviors**:
   - Fly: `FlyWithWings`, `FlyNoWay`, `FlyRocketPowered`
   - Quack: `QuackSound`, `Squeak`, `MuteQuack`
4. **Compose in Duck class**: Duck *has-a* FlyBehavior and QuackBehavior
5. **Delegate behavior**: Duck delegates to behavior objects

## Design Principles Applied

### 1. **Encapsulate What Varies**

- Behaviors are pulled out into separate classes
- Changes to behaviors don't affect Duck classes

### 2. **Program to an Interface, Not an Implementation**

   ```csharp
   public IFlyBehavior FlyBehavior { get; set; }  // Interface, not concrete class!
   ```

### 3. **Favor Composition Over Inheritance** (HAS-A vs IS-A)

- Duck **HAS-A** FlyBehavior (composition)
- Instead of Duck **IS-A** Flying thing (inheritance)
- More flexible: can change behavior at runtime!

## Class Diagram

```
┌─────────────────────────┐
│         Duck            │
├─────────────────────────┤
│ + FlyBehavior           │────────┐
│ + QuackBehavior         │─────┐  │
├─────────────────────────┤     │  │
│ + PerformFly()          │     │  │
│ + PerformQuack()        │     │  │
│ + Swim()                │     │  │
│ + Display() (abstract)  │     │  │
└─────────────────────────┘     │  │
          ▲                     │  │
          │                     │  │
    ┌─────┴─────┐               │  │
    │           │               │  │
┌───┴────┐  ┌───┴─────┐         │  │
│Mallard │  │  Model  │         │  │
│  Duck  │  │  Duck   │         │  │
└────────┘  └─────────┘         │  │
                                │  │
            ┌───────────────────┘  │
            │                      │
            ▼                      ▼
    ┌───────────────┐      ┌───────────────┐
    │ IFlyBehavior  │      │IQuackBehavior │
    └───────────────┘      └───────────────┘
            ▲                      ▲
            │                      │
    ┌───────┼─────────┐    ┌───────┼────────┐
    │       │         │    │       │        │
┌───┴──┐ ┌──┴───┐ ┌───┴──┐ │   ┌───┴──┐  ┌──┴──┐
│ Fly  │ │ Fly  │ │Rocket│ │   │Quack │  │Mute │
│ With │ │ No   │ │Pwr'd │ │   │Sound │  │Quack│
│ Wings│ │ Way  │ │      │ │   │      │  │     │
└──────┘ └──────┘ └──────┘ │   └──────┘  └─────┘
                           │  ┌────────┐
                           └──│ Squeak │
                              └────────┘
```

## Implementation Details

### Key Components

#### 1. Behavior Interfaces

```csharp
public interface IFlyBehavior
{
    void Fly();
}

public interface IQuackBehavior
{
    void Quack();
}
```

#### 2. Concrete Behavior Classes

```csharp
// Flying behaviors
public class FlyWithWings : IFlyBehavior
{
    public void Fly() => Console.WriteLine("I'm flying!!");
}

public class FlyNoWay : IFlyBehavior
{
    public void Fly() => Console.WriteLine("I can't fly");
}

public class FlyRocketPowered : IFlyBehavior
{
    public void Fly() => Console.WriteLine("I'm flying with a rocket!");
}

// Quacking behaviors
public class QuackSound : IQuackBehavior
{
    public void Quack() => Console.WriteLine("Quack");
}

public class Squeak : IQuackBehavior
{
    public void Quack() => Console.WriteLine("Squeak");
}

public class MuteQuack : IQuackBehavior
{
    public void Quack() => Console.WriteLine("<< Silence >>");
}
```

#### 3. Duck Base Class

```csharp
public abstract class Duck
{
    public IFlyBehavior FlyBehavior { get; set; } = null!;
    public IQuackBehavior QuackBehavior { get; set; } = null!;

    public void PerformFly() => FlyBehavior.Fly();
    public void PerformQuack() => QuackBehavior.Quack();
    
    public void Swim() => Console.WriteLine("All ducks float, even decoys!");
    public abstract void Display();
}
```

#### 4. Concrete Duck Classes

```csharp
public class MallardDuck : Duck
{
    public MallardDuck()
    {
        FlyBehavior = new FlyWithWings();
        QuackBehavior = new QuackSound();
    }

    public override void Display()
    {
        Console.WriteLine("I'm a real Mallard duck");
    }
}

public class ModelDuck : Duck
{
    public ModelDuck()
    {
        FlyBehavior = new FlyNoWay();
        QuackBehavior = new QuackSound();
    }

    public override void Display()
    {
        Console.WriteLine("I'm a model duck");
    }
}
```

## Usage Example

```csharp
// Create a Mallard duck
Duck mallard = new MallardDuck();
mallard.Display();           // I'm a real Mallard duck
mallard.PerformFly();        // I'm flying!!
mallard.PerformQuack();      // Quack

// Create a Model duck
Duck model = new ModelDuck();
model.Display();             // I'm a model duck
model.PerformFly();          // I can't fly

// DYNAMIC BEHAVIOR CHANGE! (The magic of Strategy Pattern)
model.FlyBehavior = new FlyRocketPowered();
model.PerformFly();          // I'm flying with a rocket!
```

## Benefits of Strategy Pattern

✅ **Flexibility**:

- Change behavior at runtime
- Mix and match behaviors

✅ **Reusability**:

- Behaviors are independent, reusable classes
- Can be shared across different duck types

✅ **Maintainability**:

- Change behavior in ONE place
- New behaviors don't affect existing code

✅ **Extensibility**:

- Add new behaviors without modifying Duck classes
- Open for extension, closed for modification

✅ **Testability**:

- Test behaviors independently
- Mock behaviors for testing

## Comparison: Before vs After

### Before (Inheritance)

- ❌ Behavior locked at compile time
- ❌ Code duplication across subclasses
- ❌ Hard to add new behaviors
- ❌ Changes ripple through hierarchy

### After (Strategy Pattern)

- ✅ Behavior changeable at runtime
- ✅ Behavior reused through composition
- ✅ Easy to add new behaviors (new class!)
- ✅ Changes isolated to behavior classes

## When to Use Strategy Pattern

✅ **Good Use Cases:**

- Multiple classes differ only in their behavior
- You need different variants of an algorithm
- Algorithm uses data clients shouldn't know about
- Multiple related conditional statements
- Need runtime behavior switching

⚠️ **Considerations:**

- Clients must be aware of different strategies
- Increases number of objects
- Communication overhead between Strategy and Context

## Real-World Examples

- **Payment methods**: Credit card, PayPal, Bitcoin
- **Sorting algorithms**: QuickSort, MergeSort, BubbleSort
- **Compression**: ZIP, RAR, 7z
- **Route calculation**: Fastest, Shortest, Scenic
- **Validation strategies**: Email, Phone, Password
- **Logging**: Console, File, Database, Cloud

## Key Takeaways from the Book

1. **Knowing the OO basics** does not make you a good OO designer
2. **Good OO designs are reusable, extensible, and maintainable**
3. **Patterns show you relationships** between classes and objects
4. **Patterns aren't invented, they're discovered**
5. **Most patterns allow some part of a system to vary independently** of all other parts
6. **Patterns provide a shared vocabulary** with other developers

## The Three Core Design Principles

### 1️⃣ Encapsulate What Varies

Identify the aspects of your application that vary and separate them from what stays the same.

### 2️⃣ Program to an Interface, Not an Implementation

Clients remain unaware of the specific types of objects they use, as long as the objects adhere to the interface.

### 3️⃣ Favor Composition Over Inheritance

HAS-A can be better than IS-A. Composition gives you more flexibility and allows runtime behavior changes.

## The Book's Wisdom

From Head First Design Patterns:

> "Knowing the OO basics does not make you a good OO designer."

> "Good OO designs are reusable, extensible and maintainable."

> "Design patterns give you a shared vocabulary with other developers. Once you've got the vocabulary, you can more easily communicate with other developers and inspire those who don't know patterns to start learning them."

> "The Strategy Pattern defines a family of algorithms, encapsulates each one, and makes them interchangeable. Strategy lets the algorithm vary independently from clients that use it."

## Related Patterns

- **State Pattern**: Similar structure but different intent (state transitions vs algorithm selection)
- **Template Method**: Defines algorithm skeleton; Strategy encapsulates whole algorithm
- **Decorator**: Adds responsibilities; Strategy changes algorithm
- **Command Pattern**: Encapsulates a request; Strategy encapsulates an algorithm

---

*"Strive for loosely coupled designs between objects that interact."* - Head First Design Patterns
