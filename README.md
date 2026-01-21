# Head First Design Patterns Examples

This project demonstrates the **Design Pattern** from the Head First Design Patterns book using C#.

## About these examples

Each chapter is a focused C# example that illustrates a single design pattern from Head First Design Patterns. The examples show the pattern's intent, participants (roles), a minimal implementation, and how to run the sample.

What you'll find in each chapter

- **Intent & When to use**: a short description of the pattern's purpose and typical use cases.
- **Key participants**: mapping of pattern roles (e.g., Component, Decorator, Subject, Observer) to concrete classes in the example.
- **How it works**: a brief explanation of the interaction between classes.
- **Trade-offs and extensions**: design considerations and simple ideas for extending the example.

See the README inside each chapter folder for a pattern-specific overview and file mapping.

## How to Build and Run

````markdown
# Head First Design Patterns — Examples (C#)

This repository collects small example projects demonstrating object-oriented design patterns from Head First Design Patterns. Each chapter/example is a focused, runnable C# project with its own README.md describing the pattern and how the sample maps to the pattern.

Included projects
- `Ch1_Intro_DuckBehaviors` — Strategy pattern; ducks delegate flying and quacking to behavior objects. See [Ch1_Intro_DuckBehaviors/README.md](Ch1_Intro_DuckBehaviors/README.md).
- `CH2_TheObserverPattern_WeatherApp` — Observer pattern; `WeatherData` notifies display observers about measurement changes. See [CH2_TheObserverPattern_WeatherApp/README.md](CH2_TheObserverPattern_WeatherApp/README.md).
- `Ch3_TheDecoratorPattern_StarbuzzCoffee` — Decorator pattern; beverages are decorated with condiment decorators. See [Ch3_TheDecoratorPattern_StarbuzzCoffee/README.md](Ch3_TheDecoratorPattern_StarbuzzCoffee/README.md).

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
dotnet run --project Ch3_TheDecoratorPattern_StarbuzzCoffee
```

Notes for contributors
- Add a folder per example/project and include a `README.md` that explains the pattern, maps files to pattern roles, and shows how to run the example.
- Keep examples small and focused on illustrating the pattern, not production-ready implementations.

Further reading
- Head First Design Patterns — companion examples and explanations.
