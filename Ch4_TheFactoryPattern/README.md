# Chapter 4: The Factory Pattern

## Overview

This chapter covers three progressively powerful factory idioms / patterns from the book, all illustrated through a **Pizza Store** scenario:

| Concept | What It Is | Files |
|---|---|---|
| **Simple Factory** | Programming idiom (not a GoF pattern) | `SimpleFactory/` |
| **Factory Method** | GoF Creational pattern | `FactoryMethod/` |
| **Abstract Factory** | GoF Creational pattern | `AbstractFactory/` |

---

## The Problem: Creating Objects

Code that uses `new` directly is coupled to a concrete class:

```csharp
// ❌ Tightly coupled — must change this code to add new types
Pizza pizza;
if (type == "cheese")    pizza = new CheesePizza();
else if (type == "clam") pizza = new ClamPizza();
else if (type == "veggie")pizza = new VeggiePizza();
// ...
```

**Design Principle:** *Program to an interface, not an implementation.* However, we still need `new` somewhere — the factory patterns tell us **where** to put that creation code and **how** to structure it to minimize coupling.

---

## Part 1 – Simple Factory (Idiom)

### Intent

Extract object creation into a separate class. All clients share the single factory and are shielded from concrete class names.

### Structure

```
SimplePizzaFactory          SimplePizzaStore
──────────────────          ────────────────
+ CreatePizza(type) ──uses──> Pizza (abstract)
                                 ↑
                    ┌────────────┼────────────┐
               CheesePizza  GreekPizza  PepperoniPizza
```

### How It Works

```csharp
// Factory encapsulates the if/switch
public class SimplePizzaFactory
{
    public Pizza? CreatePizza(string type) => type switch
    {
        "cheese"    => new CheesePizza(),
        "greek"     => new GreekPizza(),
        "pepperoni" => new PepperoniPizza(),
        _           => null
    };
}

// Store delegates creation to the factory
public class SimplePizzaStore
{
    private readonly SimplePizzaFactory _factory;

    public Pizza? OrderPizza(string type)
    {
        Pizza? pizza = _factory.CreatePizza(type);   // <-- factory call
        pizza?.Prepare(); pizza?.Bake(); pizza?.Cut(); pizza?.Box();
        return pizza;
    }
}
```

### ⚠️ Limitation

Adding a new pizza type requires **modifying `SimplePizzaFactory`** — this violates the **Open/Closed Principle**. The factory is not extensible via subclassing.

---

## Part 2 – Factory Method Pattern

### Intent

> **Define an interface for creating an object, but let subclasses decide which class to instantiate. Factory Method lets a class defer instantiation to subclasses.**

### Structure

```
PizzaStore (abstract Creator)
──────────────────────────────
# CreatePizza(type) : Pizza   ← Factory Method (abstract)
+ OrderPizza(type)  : Pizza   ← Template Method (uses factory method)

        ↙                   ↘
NYPizzaStore          ChicagoPizzaStore
(Concrete Creator)    (Concrete Creator)
# CreatePizza() →     # CreatePizza() →
  NYStyleCheesePizza    ChicagoStyleCheesePizza
  NYStyleClamPizza      ChicagoStyleClamPizza
  ...                   ...
```

### How It Works

```csharp
// ── Creator (abstract) ──────────────────────────────────────
public abstract class PizzaStore
{
    // Factory Method — subclasses decide the concrete product
    protected abstract Pizza CreatePizza(string type);

    // Template Method — stable workflow, calls the factory method
    public Pizza OrderPizza(string type)
    {
        Pizza pizza = CreatePizza(type);   // polymorphic dispatch
        pizza.Prepare(); pizza.Bake(); pizza.Cut(); pizza.Box();
        return pizza;
    }
}

// ── Concrete Creator ────────────────────────────────────────
public class NYPizzaStore : PizzaStore
{
    protected override Pizza CreatePizza(string type) => type switch
    {
        "cheese" => new NYStyleCheesePizza(),
        "clam"   => new NYStyleClamPizza(),
        ...
    };
}

// ── Concrete Product ────────────────────────────────────────
public class NYStyleCheesePizza : Pizza
{
    public NYStyleCheesePizza()
    {
        Name = "NY Style Sauce and Cheese Pizza";
        Dough = "Thin Crust Dough";
        Sauce = "Marinara Sauce";
        Toppings.Add("Grated Reggiano");
    }
}

// Chicago overrides Cut() because deep-dish is square-sliced
public class ChicagoStyleCheesePizza : Pizza
{
    public override void Cut() =>
        Console.WriteLine("Cutting the pizza into square slices");
}
```

### Key Roles

| Role | Class |
|---|---|
| Creator (abstract) | `PizzaStore` |
| Concrete Creator | `NYPizzaStore`, `ChicagoPizzaStore` |
| Product (abstract) | `Pizza` |
| Concrete Product | `NYStyleCheesePizza`, `ChicagoStyleCheesePizza`, … |

### Design Principles Applied

- **Dependency Inversion:** `PizzaStore.OrderPizza` depends only on the `Pizza` abstraction, never on `NYStyleCheesePizza` directly.
- **Open/Closed:** To add a new franchise (e.g., `CaliforniaPizzaStore`), create a new subclass — no existing code changes.

---

## Part 3 – Abstract Factory Pattern

### Intent

> **Provide an interface for creating families of related or dependent objects without specifying their concrete classes.**

### The Problem Factory Method Doesn't Solve

The Factory Method version produced region-specific pizza *classes* (`NYStyleCheesePizza`, `ChicagoStyleCheesePizza`). With 4 styles × 4 regions = 16 classes, the class count explodes as the business grows.

**Abstract Factory solves this by separating ingredient creation from pizza type creation.** The same `CheesePizza` class works in any region — it just asks its ingredient factory for the right parts.

### Structure

```
IPizzaIngredientFactory  (Abstract Factory)
─────────────────────────────────────────────
+ CreateDough()     : IDough
+ CreateSauce()     : ISauce
+ CreateCheese()    : ICheese
+ CreateVeggies()   : IVeggies[]
+ CreatePepperoni() : IPepperoni
+ CreateClams()     : IClams
        ↑                       ↑
NYPizzaIngredientFactory   ChicagoPizzaIngredientFactory
(Concrete Factory)         (Concrete Factory)
  ThinCrustDough             ThickCrustDough
  MarinaraSauce              PlumTomatoSauce
  ReggianoCheese             MozzarellaCheese
  FreshClams                 FrozenClams
  ...                        ...

PizzaStore (abstract)
─────────────────────
# CreatePizza(type) : Pizza     ← still uses Factory Method internally!

        ↙               ↘
NYPizzaStore      ChicagoPizzaStore
  creates NYPizzaIngredientFactory
  injects it into pizza objects

Pizza (abstract, Abstract Factory version)
─────────────────────────────────────────────
+ Prepare() : abstract   ← calls IPizzaIngredientFactory to get ingredients

CheesePizza          ClamPizza
PepperoniPizza       VeggiePizza
(region-independent — work with ANY ingredient factory)
```

### How It Works

```csharp
// ── Abstract Factory interface ───────────────────────────────
public interface IPizzaIngredientFactory
{
    IDough     CreateDough();
    ISauce     CreateSauce();
    ICheese    CreateCheese();
    IVeggies[] CreateVeggies();
    IPepperoni CreatePepperoni();
    IClams     CreateClams();
}

// ── Concrete Factory ─────────────────────────────────────────
public class NYPizzaIngredientFactory : IPizzaIngredientFactory
{
    public IDough  CreateDough()  => new ThinCrustDough();
    public ISauce  CreateSauce()  => new MarinaraSauce();
    public ICheese CreateCheese() => new ReggianoCheese();
    public IClams  CreateClams()  => new FreshClams();
    // ...
}

// ── Region-independent pizza ─────────────────────────────────
public class CheesePizza : Pizza
{
    private readonly IPizzaIngredientFactory _factory;
    public CheesePizza(IPizzaIngredientFactory factory) => _factory = factory;

    public override void Prepare()
    {
        Dough  = _factory.CreateDough();
        Sauce  = _factory.CreateSauce();
        Cheese = _factory.CreateCheese();
    }
}

// ── Store injects the concrete factory ──────────────────────
public class NYPizzaStore : PizzaStore
{
    protected override Pizza CreatePizza(string type)
    {
        var factory = new NYPizzaIngredientFactory();   // <-- factory injected
        return type switch
        {
            "cheese" => new CheesePizza(factory) { Name = "NY Style Cheese Pizza" },
            "clam"   => new ClamPizza(factory)   { Name = "NY Style Clam Pizza" },
            ...
        };
    }
}
```

---

## Head-to-Head Comparison: Factory Method vs Abstract Factory

| Dimension | Factory Method | Abstract Factory |
|---|---|---|
| **What it creates** | One product (e.g., a `Pizza`) | A **family** of related products (dough + sauce + cheese + …) |
| **How it extends** | Subclass the creator, override one method | Provide a new concrete factory class implementing the interface |
| **Number of methods** | One factory method per creator | Multiple factory methods (one per product in the family) |
| **Coupling point** | Creator subclass ↔ product subclass | Client ↔ abstract factory interface |
| **When to use** | When you don't know ahead of time which class you need to instantiate; defer decision to a subclass | When you need to ensure that a **set of objects** work together and you want to enforce consistency across the family |
| **Class count** | Grows per product variant (NY Cheese, Chicago Cheese, …) | Grows per region/variant once; product classes are shared |
| **Flexibility** | Easy to add new product types per subclass | Easy to swap entire product families (swap factory, everything changes) |
| **Example in chapter** | `NYPizzaStore` creates `NYStyleCheesePizza` etc. | `NYPizzaStore` injects `NYPizzaIngredientFactory` into location-neutral `CheesePizza` |

### Key Insight

> **Factory Method uses *inheritance*; Abstract Factory uses *composition*.**

- Factory Method: the subclass IS the factory — it overrides a method to create the product.
- Abstract Factory: the class HAS a factory — it holds a reference to an `IPizzaIngredientFactory` and delegates creation to it.

### When one pattern naturally leads to the other

The book shows this evolution:

1. Start with **Simple Factory** — creation in one place, but modifying it breaks OCP.
2. Move to **Factory Method** — creation deferred to subclasses, OCP satisfied, but concrete pizza subclasses multiply.
3. Move to **Abstract Factory** — ingredient families swapped as a unit, concrete pizza subclasses eliminated, maximum flexibility.

---

## Design Principles Demonstrated

| Principle | How the Chapter Illustrates It |
|---|---|
| **Encapsulate what varies** | Encapsulate object creation behind a factory |
| **Depend on abstractions** | `PizzaStore.OrderPizza` never touches a concrete pizza class |
| **Open/Closed** | Add new stores / ingredient families without touching existing code |
| **Dependency Inversion** | High-level modules (`PizzaStore`) depend on `Pizza` abstraction, not `NYStyleCheesePizza` |

---

## Project Structure

```
Ch4_TheFactoryPattern/
├── Program.cs                          ← Full demo (all three patterns)
├── README.md
│
├── SimpleFactory/                      ── Part 1: Simple Factory
│   ├── Models/
│   │   ├── Pizza.cs                    (abstract product)
│   │   ├── CheesePizza.cs
│   │   ├── GreekPizza.cs
│   │   └── PepperoniPizza.cs
│   ├── Factories/
│   │   └── SimplePizzaFactory.cs
│   └── Stores/
│       └── SimplePizzaStore.cs
│
├── FactoryMethod/                      ── Part 2: Factory Method
│   ├── Abstracts/
│   │   ├── Pizza.cs                    (abstract product / Creator base)
│   │   └── PizzaStore.cs              (abstract Creator)
│   ├── NYStyle/
│   │   ├── NYStyleCheesePizza.cs
│   │   ├── NYStylePepperoniPizza.cs
│   │   ├── NYStyleClamPizza.cs
│   │   └── NYStyleVeggiePizza.cs
│   ├── ChicagoStyle/
│   │   ├── ChicagoStyleCheesePizza.cs
│   │   ├── ChicagoStylePepperoniPizza.cs
│   │   ├── ChicagoStyleClamPizza.cs
│   │   └── ChicagoStyleVeggiePizza.cs
│   └── Stores/
│       ├── NYPizzaStore.cs             (Concrete Creator)
│       └── ChicagoPizzaStore.cs        (Concrete Creator)
│
└── AbstractFactory/                    ── Part 3: Abstract Factory
    ├── Abstracts/
    │   ├── Pizza.cs                    (abstract product, holds ingredient slots)
    │   └── PizzaStore.cs
    ├── Ingredients/
    │   ├── Interfaces/
    │   │   ├── IPizzaIngredientFactory.cs   (Abstract Factory)
    │   │   ├── IDough.cs
    │   │   ├── ISauce.cs
    │   │   ├── ICheese.cs
    │   │   ├── IVeggies.cs
    │   │   ├── IPepperoni.cs
    │   │   └── IClams.cs
    │   ├── NY/
    │   │   ├── ThinCrustDough.cs
    │   │   ├── MarinaraSauce.cs
    │   │   ├── ReggianoCheese.cs
    │   │   ├── Garlic.cs / Onion.cs / Mushroom.cs / RedPepper.cs
    │   │   ├── SlicedPepperoni.cs
    │   │   └── FreshClams.cs
    │   └── Chicago/
    │       ├── ThickCrustDough.cs
    │       ├── PlumTomatoSauce.cs
    │       ├── MozzarellaCheese.cs
    │       ├── BlackOlives.cs / Spinach.cs / EggPlant.cs
    │       └── FrozenClams.cs
    ├── Factories/
    │   ├── NYPizzaIngredientFactory.cs      (Concrete Factory)
    │   └── ChicagoPizzaIngredientFactory.cs (Concrete Factory)
    ├── Pizzas/
    │   ├── CheesePizza.cs               (region-independent products)
    │   ├── ClamPizza.cs
    │   ├── PepperoniPizza.cs
    │   └── VeggiePizza.cs
    └── Stores/
        ├── NYPizzaStore.cs
        └── ChicagoPizzaStore.cs
```

---

## Running the Demo

```bash
cd Ch4_TheFactoryPattern
dotnet run
```
