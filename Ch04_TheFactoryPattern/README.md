# Chapter 4 — Factory Patterns (Simple Factory, Factory Method, Abstract Factory)

> *"Define an interface for creating an object, but let subclasses decide which class to instantiate."*  
> *"Provide an interface for creating families of related or dependent objects without specifying their concrete classes."*  
> — Design Patterns: Elements of Reusable Object-Oriented Software

## Intent
This chapter demonstrates the evolution from ad-hoc creation to structured object creation: start with centralized creation (Simple Factory), then defer creation to subclasses (Factory Method), then create coordinated families of related products (Abstract Factory).

## Also Known As
- Factory Method: Virtual Constructor.
- Abstract Factory: Kit.

## Motivation
Object creation logic often spreads through client code (`new` + conditionals), coupling business workflows to concrete classes. The pizza store example shows how creation variability (region, style, ingredient family) should be encapsulated so order workflow remains stable.

## Chapter Summary (From the Book)
The chapter starts with a recurring code smell: concrete class selection mixed into business flow. Every new pizza type or region forces edits where ordering logic lives. This creates ripple effects and violates Open/Closed Principle.

Simple Factory is introduced first as an extraction step: move object creation into one place. It improves clarity but still requires modifying that factory whenever products change.

Factory Method then formalizes creation by moving `CreatePizza` into subclasses while keeping `OrderPizza` fixed in the base class. This isolates variation and keeps high-level workflow stable.

Abstract Factory addresses the next problem: families of related ingredients must remain consistent (NY dough/sauce/cheese vs Chicago). Instead of region-specific pizza subclasses for every combination, pizza classes become location-neutral and receive an ingredient factory.

Core takeaway: **encapsulate creation, then choose inheritance or composition depending on whether variation is product type selection or product family selection**.

## Applicability
- Creation varies by context (region, configuration, tenant, environment).
- Clients should depend on abstractions, not concrete constructors.
- Product families must be internally consistent.
- You need to add new variants without rewriting workflow logic.

## Structure
```text
Simple Factory:
  SimplePizzaStore -> SimplePizzaFactory -> Pizza variants

Factory Method:
  PizzaStore (OrderPizza template + CreatePizza factory method)
    +- NYPizzaStore
    +- ChicagoPizzaStore

Abstract Factory:
  PizzaStore -> Pizza classes + IPizzaIngredientFactory
    +- NYPizzaIngredientFactory
    +- ChicagoPizzaIngredientFactory
```

## Participants
| Role | Class in This Project | Responsibility |
|---|---|---|
| Client | `Program` | Runs the three creation approaches side by side |
| Simple Factory | `SimplePizzaFactory` | Centralized pizza construction via type key |
| Creator (Factory Method) | `FactoryMethod.Abstracts.PizzaStore` | Defines stable `OrderPizza` workflow + abstract `CreatePizza` |
| Concrete Creator | `FactoryMethod.Stores.NYPizzaStore`, `ChicagoPizzaStore` | Chooses concrete pizza implementation per region |
| Abstract Factory | `IPizzaIngredientFactory` | Creates related ingredient families |
| Concrete Abstract Factories | `NYPizzaIngredientFactory`, `ChicagoPizzaIngredientFactory` | Supplies region-consistent ingredients |
| Product | `Pizza` hierarchies (Simple/FactoryMethod/AbstractFactory namespaces) | Represents pizzas and preparation workflow |

## Collaborations
1. Program chooses a store implementation based on demonstration scenario.
2. Store executes `OrderPizza` workflow (`Prepare`, `Bake`, `Cut`, `Box`).
3. Factory Method stores decide concrete pizza via overridden `CreatePizza`.
4. Abstract Factory stores inject ingredient factory into pizza instances.
5. Pizza objects request ingredient parts from injected family factory.

## Consequences
**Benefits**
- Separates creation from use and stabilizes order workflow.
- Enables extension by adding new stores/factories, not editing core flow.
- Abstract Factory guarantees family consistency across related products.

**Liabilities**
- More types and indirection than direct construction.
- Factory Method may increase subclass count.
- Abstract Factory can be verbose when adding entirely new product dimensions.

## Implementation Notes
- Demo keeps all three approaches together to show progression clearly.
- `PrintHeader` keeps output readable by section.
- Factory Method examples use NY and Chicago stores with region-specific products.
- Abstract Factory uses ingredient factories to keep pizza classes region-agnostic.

## Sample Code
```csharp
var store = new Ch04_TheFactoryPattern.FactoryMethod.Stores.NYPizzaStore();
var pizza = store.OrderPizza("cheese");
Console.WriteLine(pizza.Name);

var afStore = new Ch04_TheFactoryPattern.AbstractFactory.Stores.ChicagoPizzaStore();
var veggie = afStore.OrderPizza("veggie");
Console.WriteLine(veggie);
```

## Known Uses
- `DbProviderFactory` style provider creation patterns.
- Dependency injection containers resolving implementations by abstraction.
- Cross-platform UI/service factories selecting environment-specific implementations.

## Related Patterns
- **Template Method**: `OrderPizza` defines invariant steps around variable creation.
- **Strategy**: can complement factories when runtime algorithm swap is needed after creation.
- **Singleton**: sometimes used for globally shared factory instances.

## Project File Map
```text
Ch04_TheFactoryPattern/
+- Program.cs
+- Ch04_TheFactoryPattern.csproj
+- SimpleFactory/
|  +- Factories/
|  +- Models/
|  +- Stores/
+- FactoryMethod/
|  +- Abstracts/
|  +- Stores/
|  +- NYStyle/
|  +- ChicagoStyle/
+- AbstractFactory/
   +- Abstracts/
   +- Factories/
   +- Ingredients/
   +- Pizzas/
   +- Stores/
```

## How to Run
`dotnet run --project Ch04_TheFactoryPattern/Ch04_TheFactoryPattern.csproj`
