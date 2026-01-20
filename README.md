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

````markdown
# Head First Design Patterns — Examples (C#)

This repository collects small example projects demonstrating object-oriented design patterns from Head First Design Patterns. Each chapter/example is a focused, runnable C# project with its own README.md describing the pattern and how the sample maps to the pattern.

Included projects
- `Ch1_Intro_DuckBehaviors` — Strategy pattern; ducks delegate flying and quacking to behavior objects. See [Ch1_Intro_DuckBehaviors/README.md](Ch1_Intro_DuckBehaviors/README.md).
- `CH2_TheObserverPattern_WeatherApp` — Observer pattern; `WeatherData` notifies display observers about measurement changes. See [CH2_TheObserverPattern_WeatherApp/README.md](CH2_TheObserverPattern_WeatherApp/README.md).

General guidance
- Each project targets .NET; check the project folder for target frameworks (e.g., `net10.0`) and the project README for specifics.
- Use Visual Studio or the .NET CLI to build and run individual projects.

Prerequisites
- .NET SDK (recommended: latest stable; examples include outputs for `net10.0` in `bin/` folders)

Build all projects
```powershell
dotnet build
```

Run a single project
```powershell
dotnet run --project Ch1_Intro_DuckBehaviors
dotnet run --project CH2_TheObserverPattern_WeatherApp
```

Notes for contributors
- Add a folder per example/project and include a `README.md` that explains the pattern, maps files to pattern roles, and shows how to run the example.
- Keep examples small and focused on illustrating the pattern, not production-ready implementations.

Further reading
- Head First Design Patterns — companion examples and explanations.
