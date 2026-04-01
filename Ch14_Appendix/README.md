# Chapter 14: Appendix - Leftover Patterns

Chapter 14 collects the remaining GoF patterns that were not covered in the earlier chapters.  
This project is intentionally organized as one demo per pattern so you can compare them side by side.

## Chapter Goal

- Complete coverage of the appendix patterns in a single runnable project
- One focused example for each pattern
- Practical guidance on when each pattern is useful

## Included Patterns

1. Bridge
2. Builder
3. Chain of Responsibility
4. Flyweight
5. Interpreter
6. Mediator
7. Memento
8. Prototype
9. Visitor

---

## How to Run

From repository root:

```powershell
dotnet run --project Ch14_Appendix
```

The output is grouped into labeled sections, one section per pattern demo.

---

## Pattern Explanations and Demo Map

Each pattern below includes:
- design intent,
- why this demo was shaped this way,
- exact class-to-role mapping,
- step-by-step execution flow so the explanation directly matches output.

## 1) Bridge

**Intent:** Decouple abstraction from implementation so both can vary independently.

**Why this pattern matters:** When two dimensions change separately (for example remotes and devices), inheritance quickly explodes into many combinations.

**Roles in the demo:**
- `Bridge/IDevice.cs`: implementation interface.
- `Bridge/Television.cs`: concrete implementor.
- `Bridge/BasicRemote.cs`: abstraction that delegates to `IDevice`.
- `Bridge/BridgeDemo.cs`: client that wires abstraction to implementation.

**Demo flow:**
1. `BridgeDemo.Run()` creates a `Television` and injects it into `BasicRemote`.
2. `TogglePower()` calls `Enable()` through `IDevice`.
3. `VolumeUp()` raises volume through the same bridge.
4. `TogglePower()` calls `Disable()`.

**Connection to output:** The printed lines show that `BasicRemote` never knows concrete TV internals; it only depends on `IDevice`.

## 2) Builder

**Intent:** Separate construction of a complex object from its representation.

**Why this pattern matters:** Many optional setup values make constructors unreadable and easy to misuse.

**Roles in the demo:**
- `Builder/Computer.cs`: final product.
- `Builder/ComputerBuilder.cs`: fluent step-by-step builder.
- `Builder/BuilderDemo.cs`: client that performs the build sequence.

**Demo flow:**
1. `BuilderDemo.Run()` creates `ComputerBuilder`.
2. Calls `WithCpu()`, `WithRamGb()`, and `WithStorage()`.
3. Calls `Build()` to return immutable configuration data in `Computer`.

**Connection to output:** The final console line confirms all selected parts are composed only at build time.

## 3) Chain of Responsibility

**Intent:** Pass a request along a chain of handlers until one handles it.

**Why this pattern matters:** Senders should not be hardcoded to one specific receiver.

**Roles in the demo:**
- `ChainOfResponsibility/SupportTicket.cs`: request object.
- `ChainOfResponsibility/SupportHandler.cs`: base chain behavior (`SetNext`, forwarding).
- `ChainOfResponsibility/SupportLevelOne.cs`: handles severity 1.
- `ChainOfResponsibility/SupportLevelTwo.cs`: handles severity 2.
- `ChainOfResponsibility/SupportManager.cs`: terminal fallback handler.
- `ChainOfResponsibility/ChainDemo.cs`: chain assembly and request submission.

**Demo flow:**
1. `ChainDemo.Run()` links L1 -> L2 -> Manager.
2. Severity 1 ticket is consumed by L1.
3. Severity 2 ticket bypasses L1 and is consumed by L2.
4. Severity 3 reaches manager fallback.

**Connection to output:** The `L1`, `L2`, and `Manager` lines prove dynamic routing without changing sender code.

## 4) Flyweight

**Intent:** Share intrinsic state to support large numbers of similar objects efficiently.

**Why this pattern matters:** Repeating common state per object wastes memory.

**Roles in the demo:**
- `Flyweight/TreeType.cs`: intrinsic shared state (`Name`, `Color`).
- `Flyweight/TreeTypeFactory.cs`: flyweight cache.
- `Flyweight/Tree.cs`: context object with extrinsic coordinates.
- `Flyweight/FlyweightDemo.cs`: builds a forest and prints flyweight count.

**Demo flow:**
1. `FlyweightDemo.Run()` requests three trees.
2. Two trees ask for the same type (`Oak`, `Green`).
3. Factory reuses one flyweight instance for both.
4. Demo prints `factory.Count` to show number of unique shared types.

**Connection to output:** `Unique flyweights created` should be less than total trees, proving sharing.

## 5) Interpreter

**Intent:** Represent a grammar and evaluate expressions against a context.

**Why this pattern matters:** Rule logic can be composed as expression trees instead of hardcoding nested conditionals.

**Roles in the demo:**
- `Interpreter/IExpression.cs`: expression contract.
- `Interpreter/VariableExpression.cs`: terminal symbol lookup.
- `Interpreter/AndExpression.cs`: binary AND node.
- `Interpreter/OrExpression.cs`: binary OR node.
- `Interpreter/NotExpression.cs`: unary NOT node.
- `Interpreter/InterpreterDemo.cs`: context setup and expression execution.

**Demo flow:**
1. `InterpreterDemo.Run()` creates context values for `A`, `B`, `C`.
2. Builds expression tree: `A AND (NOT B OR C)`.
3. Calls `Interpret(context)` at root node.
4. Result is computed recursively by child expressions.

**Connection to output:** The printed expression and boolean result show how node composition maps to evaluation.

## 6) Mediator

**Intent:** Centralize communication between collaborating objects.

**Why this pattern matters:** Direct participant-to-participant links create a dense dependency graph.

**Roles in the demo:**
- `Mediator/IChatMediator.cs`: mediator contract.
- `Mediator/ChatRoom.cs`: central coordinator.
- `Mediator/Participant.cs`: colleague objects.
- `Mediator/MediatorDemo.cs`: setup and messaging scenario.

**Demo flow:**
1. `MediatorDemo.Run()` creates one `ChatRoom`.
2. Registers three participants.
3. Sender calls `Send()`.
4. `ChatRoom.Broadcast()` forwards to everyone except sender.

**Connection to output:** Messages show participants interacting through `ChatRoom`, not directly with each other.

## 7) Memento

**Intent:** Capture object state snapshots and restore them later without exposing internals.

**Why this pattern matters:** Undo features should not break encapsulation.

**Roles in the demo:**
- `Memento/TextEditor.cs`: originator.
- `Memento/EditorMemento.cs`: snapshot value object.
- `Memento/History.cs`: caretaker stack.
- `Memento/MementoDemo.cs`: scenario with save and undo.

**Demo flow:**
1. `MementoDemo.Run()` writes `Draft v1`, saves snapshot.
2. Writes `Draft v2`, saves snapshot.
3. Writes broken `Draft v3`.
4. Pops last snapshot and restores editor state.

**Connection to output:** `After undo` confirms state rollback to last good snapshot.

## 8) Prototype

**Intent:** Create new objects by cloning existing ones.

**Why this pattern matters:** Copying a prepared baseline object is often simpler than rebuilding configuration from scratch.

**Roles in the demo:**
- `Prototype/IPrototype.cs`: cloning contract.
- `Prototype/CharacterSheet.cs`: concrete prototype.
- `Prototype/PrototypeDemo.cs`: clone scenario.

**Demo flow:**
1. `PrototypeDemo.Run()` builds an original `CharacterSheet`.
2. Calls `Clone()`.
3. Renames clone while keeping other copied values.
4. Prints original and clone to compare.

**Connection to output:** Two objects show shared baseline data with independent identity changes.

## 9) Visitor

**Intent:** Add operations to object structures without modifying element classes.

**Why this pattern matters:** When element types are stable but operations change, Visitor keeps operations extensible.

**Roles in the demo:**
- `Visitor/ICartElement.cs`: element accept contract.
- `Visitor/Book.cs` and `Visitor/Electronics.cs`: concrete element types.
- `Visitor/ICartVisitor.cs`: visitor operations per element type.
- `Visitor/PriceVisitor.cs`: concrete operation implementation.
- `Visitor/VisitorDemo.cs`: cart assembly and total calculation.

**Demo flow:**
1. `VisitorDemo.Run()` creates mixed cart items.
2. Creates `PriceVisitor`.
3. Iterates items and calls `Accept(visitor)`.
4. Each item dispatches to type-specific `Visit()`.
5. Sums returned values into cart total.

**Connection to output:** Per-item lines plus final total demonstrate double dispatch and externalized pricing logic.

---

## Comparison Matrix

| Pattern | Main Focus | Best Fit | Common Pitfall |
|---|---|---|---|
| Bridge | Separate abstraction and implementation | Two independent dimensions of change | Mistaking it for Adapter |
| Builder | Step-by-step construction | Many optional construction parameters | Overengineering simple objects |
| Chain of Responsibility | Request routing | Multiple potential handlers | Request can become silently unhandled |
| Flyweight | Memory optimization through sharing | Huge number of similar objects | Mixing intrinsic and extrinsic state |
| Interpreter | Evaluate grammar rules | Small custom expression language | Building full compiler-grade language with it |
| Mediator | Centralize interactions | Many-to-many object collaboration | God mediator with too much logic |
| Memento | Snapshot and restore state | Undo/redo and rollback flows | Large memory usage for frequent snapshots |
| Prototype | Clone pre-configured objects | Expensive or repetitive object setup | Shallow-copy bugs for nested mutable data |
| Visitor | Add operations without changing elements | Stable object structure, changing operations | Complex double-dispatch design |

---

## Suggested Practice

1. Extend one demo by adding a second concrete type (for example, a new `IDevice` in Bridge).
2. Add a second visitor operation in Visitor (for example, shipping cost calculation).
3. Add redo support to Memento using two stacks.

These exercises help reinforce where each pattern is strongest and where trade-offs appear.
