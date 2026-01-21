# Decorator Pattern — Starbuzz Coffee (CH3)

This example demonstrates the Decorator design pattern using a coffee-ordering system where beverages can be decorated with condiments at runtime.

Overview

- Intent: Attach additional responsibilities to an object dynamically. Decorators provide a flexible alternative to subclassing for extending functionality.
- When to use: when you want to add responsibilities to individual objects, not all instances of a class, and when you want combinations of behaviors without exploding the class hierarchy.

Key participants

- `Component` (here: `Beverage`): defines the interface for objects that can have responsibilities added to them.
- `ConcreteComponent` (e.g., `Espresso`, `HouseBlend`, `DarkRoast`, `Decaf`): a basic object to which additional responsibilities can be attached.
- `Decorator` (here: `CondimentDecorator`): maintains a reference to a `Component` and conforms to the `Component` interface.
- `ConcreteDecorator` (e.g., `Mocha`, `Soy`, `SteamedMilk`, `Whip`): adds responsibilities (cost, description) to the component.

How the example works

- `Beverage` provides `GetDescription()` and `Cost()` APIs.
- Concrete beverages implement `Cost()` with their base price.
- A `CondimentDecorator` wraps a `Beverage` and overrides `GetDescription()` and `Cost()` to add its own description and cost while delegating to the wrapped beverage.
- Decorators can be stacked so that multiple condiments compose their behavior and price.

Mapping to files in this project

- `Beverage` (abstract/component): [Ch3_TheDecoratorPattern_StarbuzzCoffee/Abstracts/Beverage.cs](Ch3_TheDecoratorPattern_StarbuzzCoffee/Abstracts/Beverage.cs)
- `CondimentDecorator` (decorator base): [Ch3_TheDecoratorPattern_StarbuzzCoffee/Abstracts/CondimentDecorator.cs](Ch3_TheDecoratorPattern_StarbuzzCoffee/Abstracts/CondimentDecorator.cs)
- Concrete beverages: [Ch3_TheDecoratorPattern_StarbuzzCoffee/Beverages](Ch3_TheDecoratorPattern_StarbuzzCoffee/Beverages)
- Condiment decorators: [Ch3_TheDecoratorPattern_StarbuzzCoffee/Condiments](Ch3_TheDecoratorPattern_StarbuzzCoffee/Condiments)
- Runner: [Ch3_TheDecoratorPattern_StarbuzzCoffee/Program.cs](Ch3_TheDecoratorPattern_StarbuzzCoffee/Program.cs)

Design notes and rationale

- Composition over inheritance: decorators add responsibilities by composition at runtime, avoiding numerous subclasses for each possible condiment combination.
- Single Responsibility: condiments only know how to modify description and cost, keeping concerns separated.
- Open/Closed Principle: new condiments can be added without modifying existing beverage classes.

Benefits and trade-offs

- Benefits: highly flexible, supports combinations of behaviors at runtime, reduces class explosion.
- Trade-offs: many small decorator objects increase complexity and make debugging call stacks longer; order of decorators may affect results.

Extending this example

- Add size-based pricing (e.g., `Small`/`Medium`/`Large`) and let decorators adjust costs based on size.
- Add conditional decorators that apply discounts or promotions.
- Create composite decorators that bundle common condiment combinations.

Running the example
From the workspace root run:

```powershell
dotnet run --project Ch3_TheDecoratorPattern_StarbuzzCoffee
```

Further reading

- "Design Patterns: Elements of Reusable Object-Oriented Software" — Decorator pattern.
- Head First Design Patterns — chapter on Decorator (this example).
