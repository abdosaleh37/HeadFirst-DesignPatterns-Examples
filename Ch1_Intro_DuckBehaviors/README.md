# Strategy Pattern — Duck Behaviors (CH1)

This example demonstrates the Strategy design pattern using a family of `Duck` classes that delegate behavior to separate `Behavior` objects.

Overview

- Intent: Define a family of algorithms (behaviors), encapsulate each one, and make them interchangeable. Strategy lets the algorithm vary independently from clients that use it.
- When to use: when you have related classes that differ only in their behavior, or when you want to swap algorithms at runtime without conditional statements.

Key participants

- `Context` (here: `Duck`): maintains a reference to a `Strategy` (behavior) and delegates work to it.
- `Strategy` interfaces: `IFlyBehavior` and `IQuackBehavior` define behavior contracts.
- `ConcreteStrategy`: concrete behavior implementations such as `FlyWithWings`, `FlyNoWay`, `FlyRocketPowered`, `QuackSound`, `Squeak`, and `MuteQuack`.
- `ConcreteContext` (`MallardDuck`, `ModelDuck`): concrete `Duck` classes composed with behavior objects.

How the example works

- Each `Duck` has `IFlyBehavior` and `IQuackBehavior` fields, set via constructor or with setter methods.
- When a duck needs to perform a behavior, it delegates to the corresponding strategy object (e.g., `flyBehavior.Fly()`).
- Behaviors are interchangeable at runtime — e.g., you can give a `ModelDuck` a `FlyRocketPowered` behavior to change how it flies.

Mapping to files in this project

- `IFlyBehavior`: [Ch1_Intro_DuckBehaviors/Interfaces/IFlyBehavior.cs](Ch1_Intro_DuckBehaviors/Interfaces/IFlyBehavior.cs)
- `IQuackBehavior`: [Ch1_Intro_DuckBehaviors/Interfaces/IQuackBehavior.cs](Ch1_Intro_DuckBehaviors/Interfaces/IQuackBehavior.cs)
- Concrete behaviors: [Ch1_Intro_DuckBehaviors/Behaviors](Ch1_Intro_DuckBehaviors/Behaviors)
- `Duck` (abstract/context): [Ch1_Intro_DuckBehaviors/Models/Duck.cs](Ch1_Intro_DuckBehaviors/Models/Duck.cs)
- Concrete ducks: [Ch1_Intro_DuckBehaviors/Models/MallardDuck.cs](Ch1_Intro_DuckBehaviors/Models/MallardDuck.cs), [Ch1_Intro_DuckBehaviors/Models/ModelDuck.cs](Ch1_Intro_DuckBehaviors/Models/ModelDuck.cs)
- Runner: [Ch1_Intro_DuckBehaviors/Program.cs](Ch1_Intro_DuckBehaviors/Program.cs)

Design notes and rationale

- Composition over inheritance: behaviors are separate classes rather than hard-coded in subclasses, enabling reuse and easier testing.
- Open/Closed Principle: new behaviors can be added without modifying existing ducks.
- Runtime flexibility: change behavior by calling a setter on the duck (e.g., `SetFlyBehavior(...)`).

C# / implementation details

- Use interfaces for behavior contracts and simple classes that implement them.
- Prefer constructor injection for fixed behaviors and setter methods for behaviors you expect to change at runtime.
- If multiple threads will change behaviors, synchronize access to behavior fields or use immutable replacements.

Benefits and trade-offs

- Benefits: reduces conditional logic, makes behavior modular, increases reuse and testability.
- Trade-offs: increases the number of classes, and clients must be aware of how to configure strategies.

Extending this example

- Add more behaviors (e.g., different flying styles or quack variations).
- Create composite behaviors that combine basic strategies (e.g., a `DelayedQuack` that wraps another `IQuackBehavior`).
- Add a factory to create ducks pre-wired with common behavior combinations.

Running the example
From the workspace root run:

```powershell
dotnet run --project Ch1_Intro_DuckBehaviors
```

Further reading

- "Design Patterns: Elements of Reusable Object-Oriented Software" — Strategy pattern.
- Head First Design Patterns — chapter on Strategy (this example).
