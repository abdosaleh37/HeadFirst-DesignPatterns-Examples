# Chapter 3: The Decorator Pattern - Starbuzz Coffee

## Pattern Definition

**The Decorator Pattern** attaches additional responsibilities to an object dynamically. Decorators provide a flexible alternative to subclassing for extending functionality.

## The Problem

You're designing a system for Starbuzz Coffee, a rapidly expanding coffee shop franchise. They need to track beverage orders with various condiments.

**Initial Approach (The Wrong Way - Class Explosion!):**

```csharp
class Beverage { }
class Espresso : Beverage { }
class DarkRoast : Beverage { }
class DarkRoastWithMocha : DarkRoast { }
class DarkRoastWithMochaAndWhip : DarkRoastWithMocha { }
class DarkRoastWithSoy : DarkRoast { }
class DarkRoastWithSoyAndMocha : DarkRoastWithSoy { }
class DarkRoastWithSoyAndMochaAndWhip : DarkRoastWithSoyAndMocha { }
// ... HUNDREDS of classes for all combinations!
```

**Problems with subclassing:**

1. **Class explosion** - need a class for every combination!
2. **Not flexible** - can't add condiments at runtime
3. **Maintenance nightmare** - price change affects many classes
4. **Code duplication** - similar logic repeated everywhere
5. **Not extensible** - new condiments require many new classes

**Why instance variables don't fully solve it:**

```csharp
class Beverage
{
    bool hasMilk;
    bool hasSoy;
    bool hasMocha;
    bool hasWhip;
    
    double Cost()
    {
        double cost = baseCost;
        if (hasMilk) cost += 0.10;
        if (hasSoy) cost += 0.15;
        if (hasMocha) cost += 0.20;
        if (hasWhip) cost += 0.10;
        return cost;
    }
}
```

- Still **rigid** - can't have double mocha easily
- **Violates Open/Closed** - new condiments = change Beverage class
- **Price changes** require changes to Beverage class
- Not all beverages need all condiments

## The Solution: Decorator Pattern

**Design Principle:** *Classes should be open for extension, but closed for modification.*

The Decorator Pattern lets you **wrap** objects to add functionality!

### How It Works

1. **Start with a base component** (Beverage)
2. **Create decorator** that wraps components
3. **Decorators implement same interface** as components they decorate
4. **Decorators delegate** to the component they wrap
5. **Decorators add behavior** before/after delegating
6. **Stack decorators** to add multiple responsibilities

Think of it like dressing up:

- You (Component)
- - Shirt (Decorator)
- - Sweater (Decorator)
- - Jacket (Decorator)
Each layer wraps the previous one!

## Design Principles Applied

### 1. **Open/Closed Principle**

- Open for extension (add new decorators)
- Closed for modification (don't change existing classes)

### 2. **Program to an Interface**

   ```csharp
   public abstract class CondimentDecorator : Beverage
   {
       protected Beverage beverage;  // Wrap a Beverage (interface/abstract)
   }
   ```

### 3. **Favor Composition**

- Decorators **HAS-A** (wraps) component
- Flexible: can nest decorators

### 4. **Single Responsibility**

- Each decorator adds ONE responsibility
- Easy to understand and maintain

## Class Diagram

```
┌─────────────────────────┐
│      Beverage           │ (Abstract)
├─────────────────────────┤
│ + Description: string   │
├─────────────────────────┤
│ + Cost(): double        │ (Abstract)
└─────────────────────────┘
           ▲
           │
    ┌──────┴───────────────────────┐
    │                              │
┌───┴────────────┐    ┌────────────┴────────────┐
│  Concrete      │    │  CondimentDecorator     │
│  Beverages     │    │  (Abstract)             │
├────────────────┤    ├─────────────────────────┤
│ • Espresso     │    │ - beverage: Beverage    │
│ • HouseBlend   │    ├─────────────────────────┤
│ • DarkRoast    │    │ + Cost(): double        │
│ • Decaf        │    └─────────────────────────┘
└────────────────┘               ▲
                                 │
                   ┌─────────────┼────────────┐
                   │             │            │
              ┌────┴───┐    ┌────┴───┐   ┌────┴───┐
              │ Mocha  │    │  Soy   │   │  Whip  │
              ├────────┤    ├────────┤   ├────────┤
              │+ Cost()│    │+ Cost()│   │+ Cost()│
              └────────┘    └────────┘   └────────┘
```

## Implementation Details

### Key Components

#### 1. Abstract Component (Beverage)

```csharp
public abstract class Beverage
{
    public string Description { get; set; } = "Unknown Beverage";
    
    public abstract double Cost();  // Each beverage must implement
}
```

#### 2. Concrete Components (Specific Beverages)

```csharp
public class Espresso : Beverage
{
    public Espresso()
    {
        Description = "Espresso";
    }
    
    public override double Cost()
    {
        return 1.99;
    }
}

public class HouseBlend : Beverage
{
    public HouseBlend()
    {
        Description = "House Blend Coffee";
    }
    
    public override double Cost()
    {
        return 0.89;
    }
}

public class DarkRoast : Beverage
{
    public DarkRoast()
    {
        Description = "Dark Roast Coffee";
    }
    
    public override double Cost()
    {
        return 0.99;
    }
}

public class Decaf : Beverage
{
    public Decaf()
    {
        Description = "Decaf Coffee";
    }
    
    public override double Cost()
    {
        return 1.05;
    }
}
```

#### 3. Abstract Decorator

```csharp
public abstract class CondimentDecorator : Beverage
{
    protected Beverage beverage;  // The component we're wrapping
    
    public CondimentDecorator(Beverage beverage)
    {
        this.beverage = beverage;
    }
    
    // Force subclasses to implement Description
    public abstract override string Description { get; }
}
```

#### 4. Concrete Decorators (Condiments)

```csharp
public class Mocha : CondimentDecorator
{
    public Mocha(Beverage beverage) : base(beverage) { }
    
    public override string Description
    {
        get { return beverage.Description + ", Mocha"; }
    }
    
    public override double Cost()
    {
        return beverage.Cost() + 0.20;  // Add mocha cost to wrapped beverage
    }
}

public class Soy : CondimentDecorator
{
    public Soy(Beverage beverage) : base(beverage) { }
    
    public override string Description
    {
        get { return beverage.Description + ", Soy"; }
    }
    
    public override double Cost()
    {
        return beverage.Cost() + 0.15;
    }
}

public class Whip : CondimentDecorator
{
    public Whip(Beverage beverage) : base(beverage) { }
    
    public override string Description
    {
        get { return beverage.Description + ", Whip"; }
    }
    
    public override double Cost()
    {
        return beverage.Cost() + 0.10;
    }
}

public class SteamedMilk : CondimentDecorator
{
    public SteamedMilk(Beverage beverage) : base(beverage) { }
    
    public override string Description
    {
        get { return beverage.Description + ", Steamed Milk"; }
    }
    
    public override double Cost()
    {
        return beverage.Cost() + 0.10;
    }
}
```

## Usage Example

```csharp
// Order 1: Plain Espresso
Beverage beverage1 = new Espresso();
Console.WriteLine($"{beverage1.Description} ${beverage1.Cost():0.00}");
// Output: Espresso $1.99

// Order 2: Dark Roast with Double Mocha and Whip
Beverage beverage2 = new DarkRoast();
beverage2 = new Mocha(beverage2);        // Wrap with Mocha
beverage2 = new Mocha(beverage2);        // Wrap with another Mocha (double!)
beverage2 = new Whip(beverage2);         // Wrap with Whip
Console.WriteLine($"{beverage2.Description} ${beverage2.Cost():0.00}");
// Output: Dark Roast Coffee, Mocha, Mocha, Whip $1.49

// Order 3: House Blend with Soy, Mocha, and Whip
Beverage beverage3 = new HouseBlend();
beverage3 = new Soy(beverage3);
beverage3 = new Mocha(beverage3);
beverage3 = new Whip(beverage3);
Console.WriteLine($"{beverage3.Description} ${beverage3.Cost():0.00}");
// Output: House Blend Coffee, Soy, Mocha, Whip $1.34
```

## How It Works (Step by Step)

For `beverage2` (DarkRoast + Double Mocha + Whip):

```
┌──────────────────────┐
│  Whip                │  Cost() = beverage.Cost() + 0.10
│  ┌────────────────┐  │
│  │ Mocha #2       │  │  Cost() = beverage.Cost() + 0.20
│  │ ┌────────────┐ │  │
│  │ │ Mocha #1   │ │  │  Cost() = beverage.Cost() + 0.20
│  │ │ ┌─────────┐│ │  │
│  │ │ │DarkRoast││ │  │  Cost() = 0.99
│  │ │ └─────────┘│ │  │
│  │ └────────────┘ │  │
│  └────────────────┘  │
└──────────────────────┘

beverage2.Cost() calls:
→ Whip.Cost() = Mocha2.Cost() + 0.10
  → Mocha2.Cost() = Mocha1.Cost() + 0.20
    → Mocha1.Cost() = DarkRoast.Cost() + 0.20
      → DarkRoast.Cost() = 0.99
    ← returns 1.19
  ← returns 1.39
← returns 1.49
```

## Benefits of Decorator Pattern

✅ **Flexibility**:

- Add responsibilities at runtime
- Mix and match decorators

✅ **Open/Closed Principle**:

- Extend without modifying existing code
- New decorators don't affect existing classes

✅ **Single Responsibility**:

- Each decorator has one job
- Easy to understand and maintain

✅ **Unlimited Combinations**:

- Stack decorators in any order
- No class explosion!

✅ **Transparency**:

- Clients treat decorated objects same as base objects
- Decorators are transparent

## Comparison: Before vs After

### Before (Subclassing)

- ❌ Class explosion (hundreds of classes!)
- ❌ Rigid combinations
- ❌ Can't add at runtime
- ❌ Code duplication
- ❌ Hard to maintain

### After (Decorator Pattern)

- ✅ Few classes (base + decorators)
- ✅ Flexible combinations
- ✅ Runtime composition
- ✅ Code reuse
- ✅ Easy to extend

## When to Use Decorator Pattern

✅ **Good Use Cases:**

- Add responsibilities to objects dynamically
- Need flexible alternative to subclassing
- Want to avoid class explosion
- Responsibilities can be withdrawn
- Extension by subclassing is impractical

⚠️ **Considerations:**

- Many small objects (can be complex to debug)
- Decorators aren't identical to component (type checks fail)
- Order of decorators can matter
- Can complicate instantiation code

## Real-World Examples

- **I/O Streams in .NET/Java**:

  ```csharp
  Stream stream = new FileStream("data.txt");
  stream = new BufferedStream(stream);
  stream = new GZipStream(stream);
  ```

- **ASP.NET Middleware**: Each middleware decorates the request pipeline
- **Logging**: Add logging behavior to existing classes
- **Caching**: Wrap expensive operations with caching
- **UI Components**: Add scrollbars, borders, shadows to windows
- **Text Formatting**: Bold, italic, underline

## .NET Framework Examples

### Stream Decorators

```csharp
// File → Buffer → Compression
FileStream fileStream = new FileStream("file.txt", FileMode.Open);
BufferedStream bufferedStream = new BufferedStream(fileStream);
GZipStream gzipStream = new GZipStream(bufferedStream, CompressionMode.Compress);
```

### ASP.NET Core Middleware

```csharp
app.UseAuthentication();  // Decorates pipeline
app.UseAuthorization();   // Decorates pipeline
app.UseResponseCompression();  // Decorates pipeline
```

## Potential Issues and Solutions

### Issue 1: Type-Specific Code

```csharp
// Problem: instanceof/is checks break with decorators
if (beverage is DarkRoast)  // Fails if beverage is decorated!
{
    // Do something specific to DarkRoast
}
```

**Solution**: Design to rely on abstraction, not concrete types

### Issue 2: Too Many Small Classes

**Solution**: Accept it - the flexibility is worth it!

### Issue 3: Order Matters

```csharp
// Different order = different behavior
new Beverage(new Tax(new Discount(price)));  // Tax on discounted price
new Beverage(new Discount(new Tax(price)));  // Discount on taxed price
```

**Solution**: Document expected order or enforce through API design

## Advanced: Decorator with Sizes

```csharp
public abstract class Beverage
{
    public enum Size { TALL, GRANDE, VENTI }
    public Size BeverageSize { get; set; } = Size.TALL;
    
    public abstract double Cost();
}

public class Mocha : CondimentDecorator
{
    public override double Cost()
    {
        double cost = beverage.Cost();
        
        if (beverage.BeverageSize == Size.TALL)
            cost += 0.15;
        else if (beverage.BeverageSize == Size.GRANDE)
            cost += 0.20;
        else if (beverage.BeverageSize == Size.VENTI)
            cost += 0.25;
            
        return cost;
    }
}
```

## Key Takeaways from the Book

1. **Decorators have the same supertype** as the objects they decorate
2. **You can use decorators to wrap objects** with new behavior
3. **Decorators can be used transparently** in place of original objects
4. **Objects can be decorated at runtime**
5. **The Decorator Pattern provides an alternative to subclassing** for extending behavior
6. **Decorator adds its own behavior** before/after delegating

## The Book's Wisdom

From Head First Design Patterns:

> "Classes should be open for extension, but closed for modification."

> "The Decorator Pattern attaches additional responsibilities to an object dynamically. Decorators provide a flexible alternative to subclassing for extending functionality."

> "Designs should be open for extension but closed for modification."

> "Our goal is to allow classes to be easily extended to incorporate new behavior without modifying existing code."

## Related Patterns

- **Adapter**: Changes interface; Decorator adds responsibilities
- **Composite**: Decorator adds responsibilities; Composite represents part-whole hierarchies
- **Strategy**: Changes guts; Decorator changes skin
- **Proxy**: Controls access; Decorator adds responsibilities
- **Chain of Responsibility**: Can pass requests through decorators

---

*"Favor composition over inheritance. Composition gives you a lot more flexibility."* - Head First Design Patterns
