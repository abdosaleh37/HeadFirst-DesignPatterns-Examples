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

This solution contains mostly standalone C# console applications demonstrating specific design patterns, plus a documentation-only summary chapter:

### Chapter 1: Strategy Pattern - Duck Behaviors

**Pattern:** Define a family of algorithms, encapsulate each one, and make them interchangeable.

**Key Concepts:** Composition over inheritance, encapsulating what varies, programming to interfaces

📁 [Ch1_Intro_TheStrategyPattern/README.md](Ch1_Intro_TheStrategyPattern/README.md)

---

### Chapter 2: Observer Pattern - Weather Station

**Pattern:** Define a one-to-many dependency between objects so that when one object changes state, all dependents are notified automatically.

**Key Concepts:** Loose coupling, push vs pull models, dynamic observer registration

📁 [Ch2_TheObserverPattern/README.md](Ch2_TheObserverPattern/README.md)

---

### Chapter 3: Decorator Pattern - Starbuzz Coffee

**Pattern:** Attach responsibilities to objects dynamically using wrappers.

**Key Concepts:** Open/Closed Principle, composition, flexible behavior extension

📁 [Ch3_TheDecoratorPattern/README.md](Ch3_TheDecoratorPattern/README.md)

---

### Chapter 4: Factory Patterns - Pizza Store

**Pattern Group:** Simple Factory, Factory Method, and Abstract Factory.

**Key Concepts:** Encapsulated object creation, dependency inversion, product families

📁 [Ch4_TheFactoryPattern/README.md](Ch4_TheFactoryPattern/README.md)

---

### Chapter 5: Singleton Pattern - Chocolate Factory

**Pattern:** Ensure a class has exactly one instance and provide global access.

**Key Concepts:** Single instance control, thread safety, eager vs lazy initialization

📁 [Ch5_TheSingletonPattern/README.md](Ch5_TheSingletonPattern/README.md)

---

### Chapter 6: Command Pattern - Remote Control

**Pattern:** Encapsulate a request as an object.

**Key Concepts:** Undo support, macro commands, decoupled invoker/receiver

📁 [Ch6_TheCommandPattern/README.md](Ch6_TheCommandPattern/README.md)

---

### Chapter 7A: Adapter Pattern

**Pattern:** Convert one interface into another expected by the client.

**Key Concepts:** Object adapters, legacy integration, interface translation

📁 [Ch7_A_TheAdapterPattern/README.md](Ch7_A_TheAdapterPattern/README.md)

---

### Chapter 7B: Facade Pattern

**Pattern:** Provide a simplified interface to a subsystem.

**Key Concepts:** Subsystem simplification, reduced coupling, orchestration API

📁 [Ch7_B_TheFacadePattern/README.md](Ch7_B_TheFacadePattern/README.md)

---

### Chapter 8: Template Method Pattern

**Pattern:** Define an algorithm skeleton and let subclasses fill specific steps.

**Key Concepts:** Inversion of control, hooks, code reuse through templates

📁 [Ch8_TheTemplateMethodPattern/README.md](Ch8_TheTemplateMethodPattern/README.md)

---

### Chapter 9A: Iterator Pattern

**Pattern:** Provide a way to access elements of a collection sequentially without exposing representation.

**Key Concepts:** Traversal abstraction, aggregate interfaces, decoupled iteration

📁 [Ch9_A_TheIteratorPattern/README.md](Ch9_A_TheIteratorPattern/README.md)

---

### Chapter 9B: Composite Pattern

**Pattern:** Compose objects into tree structures to represent part-whole hierarchies.

**Key Concepts:** Uniform treatment of leaf/composite objects, recursive composition

📁 [Ch9_B_TheCompositePattern/README.md](Ch9_B_TheCompositePattern/README.md)

---

### Chapter 10: State Pattern - Gumball Machine

**Pattern:** Allow an object to change behavior when internal state changes.

**Key Concepts:** State objects, transition management, removal of conditional logic

📁 [Ch10_TheStatePattern/README.md](Ch10_TheStatePattern/README.md)

---

### Chapter 11: Proxy Pattern - Remote, Virtual, Protection

**Pattern:** Provide a surrogate or placeholder for another object to control access.

**Key Concepts:** Remote access, lazy loading, authorization boundaries

📁 [Ch11_TheProxyPattern/README.md](Ch11_TheProxyPattern/README.md)

---

### Chapter 12: Compound Pattern - Duck Simulator + MVC

**Pattern Type:** Pattern composition (multiple patterns working together).

**Key Concepts:** Adapter, Decorator, Abstract Factory, Composite, Observer,
and MVC collaboration

📁 [Ch12_TheCompoundPattern/README.md](Ch12_TheCompoundPattern/README.md)

---

### Chapter 13: Better Living With Patterns

**Chapter Type:** Summary chapter focused on practical pattern usage in real design.

**Key Concepts:** Pattern mindset, composition of patterns, trade-offs, and avoiding overengineering

📁 [Ch13_BetterLivingWithPatterns/README.md](Ch13_BetterLivingWithPatterns/README.md)

---

## 🏗️ Solution Structure

Most chapters are organized as separate .NET console applications with:

```
ChX_PatternName_Example/
├── README.md                    # Detailed pattern explanation
├── Program.cs                   # Entry point demonstrating the pattern
├── ChX_PatternName.csproj       # Project file
├── Interfaces/                  # Pattern interfaces
├── Models/ or Abstracts/        # Core implementation classes
├── Behaviors/ or Condiments/    # Pattern-specific components
└── bin/obj/                     # Build outputs
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
dotnet build Ch1_Intro_TheStrategyPattern
```

### Running Examples

Run any project individually:

```powershell
dotnet run --project Ch1_Intro_TheStrategyPattern
dotnet run --project Ch2_TheObserverPattern
dotnet run --project Ch3_TheDecoratorPattern
dotnet run --project Ch4_TheFactoryPattern
dotnet run --project Ch5_TheSingletonPattern
dotnet run --project Ch6_TheCommandPattern
dotnet run --project Ch7_A_TheAdapterPattern
dotnet run --project Ch7_B_TheFacadePattern
dotnet run --project Ch8_TheTemplateMethodPattern
dotnet run --project Ch9_A_TheIteratorPattern
dotnet run --project Ch9_B_TheCompositePattern
dotnet run --project Ch10_TheStatePattern
dotnet run --project Ch11_TheProxyPattern
dotnet run --project Ch12_TheCompoundPattern
```

Chapter 13 is intentionally documentation-only and does not include a runnable project.

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