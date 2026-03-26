# Chapter 12: The Compound Pattern

## Pattern Definition

The **Compound Pattern** is not a single Gang of Four pattern. It is a
deliberate composition of multiple patterns that collaborate to solve a larger
problem cleanly.

In this chapter, the book uses two major examples:

1. A Duck Simulator that combines several patterns in one domain model
2. MVC as a larger architectural compound pattern

## Chapter Summary from the Book

Chapter 12 answers a practical question: what happens when one pattern is not
enough?

Instead of inventing a monolithic mega-pattern, the chapter shows how to build
systems by composing focused patterns, each handling one concern:

- **Adapter** integrates incompatible interfaces (Goose into Duck world)
- **Decorator** adds behavior transparently (count quacks)
- **Abstract Factory** centralizes and controls object creation strategy
- **Composite** treats individual ducks and groups of ducks uniformly
- **Observer** decouples event sources (quackers) from event listeners

Then the chapter zooms out to **MVC**, where Observer and strategy-like
controller behavior naturally combine with model/view separation into a stable,
scalable architecture.

Core lesson: combining patterns intentionally yields systems that are easier to
extend, test, and reason about than a single giant design.

## The Problem

### Problem A: Duck Simulator Complexity

Requirements grow quickly:

- Support many duck types
- Integrate geese without changing duck clients
- Count quacks without modifying duck classes directly
- Group ducks into flocks, including nested flocks
- Observe quack events for monitoring/logging

If solved with one class hierarchy and conditionals, design becomes rigid.

### Problem B: UI and Domain Entanglement

In music/beat control style applications, if view and model logic are mixed,
every UI change risks breaking domain behavior and vice versa.

## Solution Overview

This project implements both chapter examples:

1. **Duck Simulator Compound**
2. **MVC Beat Model (console version)**

## Part 1: Duck Simulator Compound

### Patterns Used and Why

1. **Adapter**

- `Goose` has `Honk()` instead of `Quack()`
- `GooseAdapter` implements `IQuackable` and forwards to `Honk()`

1. **Decorator**

- `QuackCounter` wraps any `IQuackable`
- increments a shared quack count without changing duck classes

1. **Abstract Factory**

- `IAbstractDuckFactory` defines duck creation operations
- `DuckFactory` creates normal ducks
- `CountingDuckFactory` creates `QuackCounter`-wrapped ducks

1. **Composite**

- `Flock` implements `IQuackable`
- a flock can contain ducks and other flocks
- client calls `Quack()` once and recursion handles the tree

1. **Observer**

- `IObserver` and `IQuackObservable` define notification contracts
- `Quackologist` receives updates whenever a quacker acts

### Duck Compound Class Diagram (Text)

```
IQuackable (also IQuackObservable)
  ^
  |-- MallardDuck / RedheadDuck / DuckCall / RubberDuck
  |-- GooseAdapter (adapts Goose.Honk)
  |-- QuackCounter (decorator around IQuackable)
  |-- Flock (composite of IQuackable)

IAbstractDuckFactory
  |-- DuckFactory
  |-- CountingDuckFactory

IObserver
  |-- Quackologist
```

## Part 2: MVC as a Compound Pattern

This repository uses a console-friendly Beat Model variant to show the chapter
architecture without requiring GUI frameworks.

### MVC Responsibilities

1. **Model (`BeatModel`)**

- owns BPM state and beat events
- exposes observer registration APIs for beat and BPM updates

1. **View (`ConsoleDJView`)**

- observes model changes
- renders beat/BPM output
- forwards user intent to controller

1. **Controller (`BeatController`)**

- translates user actions into model operations
- does not perform view rendering or own domain state

### Pattern Relationships Inside MVC

- Observer keeps model and views loosely coupled
- Controller encapsulates interaction policies
- Model stays independent of concrete view implementation

## Design Principles Applied

1. **Program to interfaces**

- clients depend on `IQuackable`, `IAbstractDuckFactory`, `IBeatModel`,
  `IController`

1. **Favor composition over inheritance**

- decorators and composites rely on object composition

1. **Open/Closed Principle**

- add new quackers, observers, or factories without modifying stable clients

1. **Single Responsibility**

- each pattern piece handles one type of change

## Project Structure

```
Ch12_TheCompoundPattern/
|-- Interfaces/
|   |-- IObserver.cs
|   |-- IQuackObservable.cs
|   |-- IQuackable.cs
|   |-- IAbstractDuckFactory.cs
|   |-- IBeatObserver.cs
|   |-- IBpmObserver.cs
|   |-- IBeatModel.cs
|   `-- IController.cs
|-- Models/
|   |-- Observable.cs
|   |-- QuackableBase.cs
|   |-- MallardDuck.cs
|   |-- RedheadDuck.cs
|   |-- DuckCall.cs
|   |-- RubberDuck.cs
|   |-- Goose.cs
|   `-- MVC/
|       |-- BeatModel.cs
|       |-- BeatController.cs
|       `-- ConsoleDJView.cs
|-- Adapters/
|   `-- GooseAdapter.cs
|-- Decorators/
|   `-- QuackCounter.cs
|-- Factories/
|   |-- DuckFactory.cs
|   `-- CountingDuckFactory.cs
|-- Composites/
|   `-- Flock.cs
|-- Observers/
|   `-- Quackologist.cs
|-- Program.cs
`-- README.md
```

## Program Walkthrough

`Program.cs` runs two demos in sequence:

1. Builds composite flocks using counting factory and goose adapter
2. Registers `Quackologist` observer
3. Simulates quack flow and prints total counted quacks
4. Builds MVC model-view-controller triad
5. Simulates controller actions (start/stop/BPM changes) and view updates

Run chapter 12:

```powershell
dotnet run --project Ch12_TheCompoundPattern/Ch12_TheCompoundPattern.csproj
```

## Benefits of the Compound Pattern Approach

- Complex behavior stays modular and replaceable
- Feature growth does not require redesigning the entire system
- Object creation strategy is centralized and test-friendly
- Observability is added without tight coupling
- MVC keeps domain logic independent from presentation details

## Key Takeaway

Chapter 12 teaches architectural maturity: use multiple small, proven patterns
in concert rather than forcing one pattern to solve every concern.
