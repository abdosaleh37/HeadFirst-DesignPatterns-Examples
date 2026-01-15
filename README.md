# Head First Design Patterns Examples

This project demonstrates the **Design Pattern** from the Head First Design Patterns book using C#.

## Design Pattern: Strategy Pattern

The Strategy Pattern defines a family of algorithms, encapsulates each one, and makes them interchangeable. Strategy lets the algorithm vary independently from clients that use it.

## Key Concepts

- **Composition over Inheritance**: Instead of inheriting behaviors, ducks are composed with behavior objects
- **Program to Interfaces**: Behaviors are defined by interfaces, not concrete implementations
- **Favor Composition**: Ducks delegate behavior to composed objects rather than implementing behaviors themselves
- **Runtime Flexibility**: Behaviors can be changed at runtime using setter methods

## How to Build and Run

### Prerequisites
- .NET SDK (6.0 or later)

### Build
```bash
dotnet build
```

### Run
```bash
dotnet run --project Intro_DuckBehaviors
```

## Example Usage

The program creates different types of ducks and demonstrates:
- Different flying behaviors (flying with wings, not flying, rocket-powered)
- Different quacking behaviors (quack, squeak, mute)
- Dynamic behavior changes at runtime

## Learning Outcomes

This example teaches:
1. How to identify aspects of your code that vary and separate them from what stays the same
2. How to program to an interface, not an implementation
3. How to favor composition over inheritance
4. How behaviors can be changed at runtime for maximum flexibility
