# Head First Design Patterns - C# Examples

This repository contains practical, hands-on implementations of the classic design patterns from the book **"Head First Design Patterns"** by Eric Freeman and Elisabeth Robson, translated from Java to C#.

## 🎯 Purpose and Intent

This solution serves as a comprehensive learning resource for developers who want to:

- **Understand object-oriented design patterns** through real-world examples
- **Learn C# implementations** of patterns originally presented in Java
- **See patterns in action** with runnable, focused examples that demonstrate each pattern's core principles
- **Build better software** by applying proven design solutions to common problems

Each project is intentionally kept simple and focused on demonstrating a single pattern, making it easy to understand the pattern's intent, structure, and benefits without getting lost in complex business logic.

## 📚 What's Inside

This solution contains multiple standalone C# console applications, each demonstrating a specific design pattern:

### Chapter 1: Strategy Pattern - Duck Behaviors

**Pattern:** Define a family of algorithms, encapsulate each one, and make them interchangeable.

**Example:** A duck simulator where different duck types can fly and quack in different ways. Behaviors are encapsulated as separate classes rather than inherited, allowing runtime behavior changes.

**Key Concepts:** Composition over inheritance, encapsulating what varies, programming to interfaces

📁 [Ch1_Intro_DuckBehaviors/README.md](Ch1_Intro_DuckBehaviors/README.md)

---

### Chapter 2: Observer Pattern - Weather Station

**Pattern:** Define a one-to-many dependency between objects so that when one object changes state, all dependents are notified automatically.

**Example:** A weather monitoring application where `WeatherData` acts as the subject, and various display elements (current conditions, statistics, forecast) act as observers that get updated when measurements change.

**Key Concepts:** Loose coupling, push vs pull models, dynamic registration/removal of observers

📁 [Ch2_TheObserverPattern_WeatherApp/README.md](Ch2_TheObserverPattern_WeatherApp/README.md)

---

### Chapter 3: Decorator Pattern - Starbuzz Coffee

**Pattern:** Attach additional responsibilities to an object dynamically, providing a flexible alternative to subclassing.

**Example:** A coffee shop ordering system where beverages (Espresso, DarkRoast, Decaf) can be decorated with condiments (Mocha, Soy, Whip) at runtime. Each decorator adds its own cost and description.

**Key Concepts:** Open/Closed Principle, wrapping objects, dynamic behavior composition

📁 [Ch3_TheDecoratorPattern_StarbuzzCoffee/README.md](Ch3_TheDecoratorPattern_StarbuzzCoffee/README.md)

---

### Chapter 5: Singleton Pattern - Chocolate Factory

**Pattern:** Ensure a class has only one instance and provide a global point of access to it.

**Example:** A chocolate boiler controller that must have exactly one instance to prevent multiple processes from filling, boiling, or draining simultaneously.

**Key Concepts:** Single instance control, global access point, thread safety, lazy vs eager initialization

📁 [Ch5_TheSingletonPattern_TheChocolateFactory/README.md](Ch5_TheSingletonPattern_TheChocolateFactory/README.md)

---

## 🏗️ Solution Structure

Each chapter is organized as a separate .NET console application with:

```
ChX_PatternName_Example/
├── README.md                    # Detailed pattern explanation
├── Program.cs                   # Entry point demonstrating the pattern
├── ChX_PatternName.csproj      # Project file
├── Interfaces/                  # Pattern interfaces
├── Models/ or Abstracts/       # Core implementation classes
├── Behaviors/ or Condiments/   # Pattern-specific components
└── bin/obj/                    # Build outputs
```

## 🚀 Getting Started

### Prerequisites

- **.NET SDK** (version 10.0 or later recommended)
- **Visual Studio 2022** or **Visual Studio Code** (optional but recommended)
- Basic understanding of **C# and object-oriented programming**

### Building the Solution

Build all projects at once:

```powershell
dotnet build
```

Build a specific project:

```powershell
dotnet build Ch1_Intro_DuckBehaviors
```

### Running Examples

Run any project individually:

```powershell
dotnet run --project Ch1_Intro_DuckBehaviors
dotnet run --project Ch2_TheObserverPattern_WeatherApp
dotnet run --project Ch3_TheDecoratorPattern_StarbuzzCoffee
dotnet run --project Ch5_TheSingletonPattern_TheChocolateFactory
```

Or open the solution in Visual Studio and run individual projects through the IDE.

## 📖 How to Use This Repository

1. **Start with the chapter README** - Each chapter folder contains a detailed README explaining:
   - The problem the pattern solves
   - Why naive approaches fail
   - How the pattern works
   - Class diagrams and file mappings
   - Design principles illustrated

2. **Read the code** - The code is well-commented and structured to be educational

3. **Run the examples** - See the patterns in action with console output

4. **Experiment** - Modify the code to deepen your understanding

## 🎓 Learning Path

**Recommended order for beginners:**

1. **Strategy Pattern** (Ch1) - Introduces composition over inheritance
2. **Observer Pattern** (Ch2) - Demonstrates loose coupling and one-to-many relationships
3. **Decorator Pattern** (Ch3) - Shows dynamic behavior composition
4. **Singleton Pattern** (Ch5) - Covers object creation and instance control

## 🔑 Key Design Principles Demonstrated

Throughout these examples, you'll see these fundamental OO design principles:

- ✅ **Encapsulate what varies**
- ✅ **Favor composition over inheritance**
- ✅ **Program to interfaces, not implementations**
- ✅ **Strive for loosely coupled designs**
- ✅ **Classes should be open for extension but closed for modification** (Open/Closed Principle)
- ✅ **Depend on abstractions, not concrete classes** (Dependency Inversion Principle)

## 🤝 Contributing

Feel free to:

- Add new pattern examples following the existing structure
- Improve documentation
- Fix bugs or enhance existing examples
- Add unit tests

**When adding a new chapter:**

1. Create a new folder: `ChX_PatternName_Example`
2. Include a comprehensive `README.md` explaining the pattern
3. Structure code clearly with separate folders for interfaces, models, etc.
4. Add console output demonstrating the pattern in action
5. Update this main README with your new chapter

## 📝 Notes

- These examples are **educational implementations** focused on clarity over production-ready code
- Some C# idioms and features are used that differ from the original Java examples
- Thread safety and advanced scenarios are discussed in individual chapter READMEs where relevant

## 📚 Additional Resources

- [Head First Design Patterns (Book)](https://www.oreilly.com/library/view/head-first-design/9781492077992/)
- [Design Patterns: Elements of Reusable Object-Oriented Software](https://en.wikipedia.org/wiki/Design_Patterns) (Gang of Four)
- [Microsoft C# Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/)

---

**Happy Learning! 🎉** Each pattern you master is a powerful tool in your software design toolkit.
