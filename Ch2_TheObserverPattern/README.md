# Chapter 2: The Observer Pattern - Weather Station

## Pattern Definition

**The Observer Pattern** defines a one-to-many dependency between objects so that when one object changes state, all of its dependents are notified and updated automatically.

## The Problem

You've been asked to build a weather monitoring application that:

- Gets data from a `WeatherData` object (temperature, humidity, pressure)
- Displays current conditions, statistics, and forecasts on multiple display devices
- Must be **extensible** - third parties can create custom displays

**Initial Approach (The Wrong Way):**

```csharp
public class WeatherData
{
    public void MeasurementsChanged()
    {
        float temp = GetTemperature();
        float humidity = GetHumidity();
        float pressure = GetPressure();
        
        // Directly updating displays - PROBLEMS!
        currentConditionsDisplay.Update(temp, humidity, pressure);
        statisticsDisplay.Update(temp, humidity, pressure);
        forecastDisplay.Update(temp, humidity, pressure);
        // Can't add new displays without modifying this code!
    }
}
```

**Problems with direct updates:**

1. **Not extensible** - can't add new displays without changing code
2. **Tight coupling** - WeatherData knows about concrete display classes
3. **Not dynamic** - can't add/remove displays at runtime
4. **Violates Open/Closed Principle** - not open for extension, not closed for modification
5. **Hard to test** - can't test WeatherData without all displays

## The Solution: Observer Pattern

**Design Principle:** *Strive for loosely coupled designs between objects that interact.*

The Observer Pattern provides a clean way to achieve this!

### How It Works

1. **Subject** (WeatherData) maintains a list of observers
2. **Observers** register/unregister with the subject
3. When subject's state changes, it **notifies all observers**
4. Observers **pull** data they need from the subject or receive it via **push**
5. Subject doesn't know or care about concrete observer types!

## Design Principles Applied

### 1. **Loose Coupling**

- Subject only knows that observers implement the `IObserver` interface
- Can add new observers without modifying the subject
- Observers and subjects can be reused independently

### 2. **Program to an Interface**

   ```csharp
   public List<IObserver> Observers { get; private set; }
   ```

- Subject works with the `IObserver` interface, not concrete classes

### 3. **Open/Closed Principle**

- Open for extension (add new observers)
- Closed for modification (don't change subject)

## Class Diagram

```
┌─────────────────────────┐
│      <<interface>>      │
│       ISubject          │
├─────────────────────────┤
│ + RegisterObserver()    │
│ + RemoveObserver()      │
│ + NotifyObservers()     │
└─────────────────────────┘
           ▲
           │ implements
           │
┌──────────┴──────────────┐
│     WeatherData         │
├─────────────────────────┤
│ - observers: List       │
│ - temperature: float    │
│ - humidity: float       │
│ - pressure: float       │
├─────────────────────────┤
│ + RegisterObserver()    │
│ + RemoveObserver()      │
│ + NotifyObservers()     │
│ + SetMeasurements()     │
└─────────────────────────┘
           │
           │ notifies
           ▼
┌─────────────────────────┐
│      <<interface>>      │
│       IObserver         │
├─────────────────────────┤
│ + Update()              │
└─────────────────────────┘
           ▲
           │ implements
     ┌─────┼─────────┬──────────┐
     │     │         │          │
┌────┴───┐ │ ┌──────┴───┐ ┌────┴────────┐
│Current │ │ │Statistics│ │  Forecast   │
│Display │ │ │ Display  │ │  Display    │
└────────┘ │ └──────────┘ └─────────────┘
           │
    ┌──────┴────────┐
    │  HeatIndex    │
    │   Display     │
    └───────────────┘
```

## Implementation Details

### Key Components

#### 1. Subject Interface

```csharp
public interface ISubject
{
    void RegisterObserver(IObserver o);
    void RemoveObserver(IObserver o);
    void NotifyObservers();
}
```

#### 2. Observer Interface

```csharp
public interface IObserver
{
    void Update();  // Called when subject's state changes
}
```

#### 3. Display Interface (Optional but recommended)

```csharp
public interface IDisplayElement
{
    void Display();  // Display the information
}
```

#### 4. Concrete Subject (WeatherData)

```csharp
public class WeatherData : ISubject
{
    private List<IObserver> observers;
    public float Temperature { get; private set; }
    public float Humidity { get; private set; }
    public float Pressure { get; private set; }

    public WeatherData()
    {
        observers = new List<IObserver>();
    }

    public void RegisterObserver(IObserver o)
    {
        observers.Add(o);
    }

    public void RemoveObserver(IObserver o)
    {
        observers.Remove(o);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update();
        }
    }

    public void MeasurementsChanged()
    {
        NotifyObservers();
    }

    public void SetMeasurements(float temperature, float humidity, float pressure)
    {
        this.Temperature = temperature;
        this.Humidity = humidity;
        this.Pressure = pressure;
        MeasurementsChanged();
    }
}
```

#### 5. Concrete Observer (CurrentConditionsDisplay)

```csharp
public class CurrentConditionsDisplay : IObserver, IDisplayElement
{
    private float temperature;
    private float humidity;
    private WeatherData weatherData;

    public CurrentConditionsDisplay(WeatherData weatherData)
    {
        this.weatherData = weatherData;
        weatherData.RegisterObserver(this);  // Register with subject
    }

    public void Update()
    {
        // Pull data from subject
        this.temperature = weatherData.Temperature;
        this.humidity = weatherData.Humidity;
        Display();
    }

    public void Display()
    {
        Console.WriteLine($"Current conditions: {temperature}F degrees and {humidity}% humidity");
    }
}
```

### Additional Display Examples

#### Statistics Display (Tracks min/max/average)

```csharp
public class StatisticsDisplay : IObserver, IDisplayElement
{
    private float maxTemp = 0.0f;
    private float minTemp = 200;
    private float tempSum = 0.0f;
    private int numReadings;
    private WeatherData weatherData;

    public void Update()
    {
        float temp = weatherData.Temperature;
        tempSum += temp;
        numReadings++;

        if (temp > maxTemp) maxTemp = temp;
        if (temp < minTemp) minTemp = temp;

        Display();
    }

    public void Display()
    {
        Console.WriteLine($"Avg/Max/Min temperature = {tempSum / numReadings}/{maxTemp}/{minTemp}");
    }
}
```

#### Forecast Display (Simple weather prediction)

```csharp
public class ForecastDisplay : IObserver, IDisplayElement
{
    private float currentPressure = 29.92f;
    private float lastPressure;
    private WeatherData weatherData;

    public void Update()
    {
        lastPressure = currentPressure;
        currentPressure = weatherData.Pressure;
        Display();
    }

    public void Display()
    {
        Console.Write("Forecast: ");
        if (currentPressure > lastPressure)
            Console.WriteLine("Improving weather on the way!");
        else if (currentPressure == lastPressure)
            Console.WriteLine("More of the same");
        else
            Console.WriteLine("Watch out for cooler, rainy weather");
    }
}
```

#### Heat Index Display (Computed value)

```csharp
public class HeatIndexDisplay : IObserver, IDisplayElement
{
    private float heatIndex = 0.0f;
    private WeatherData weatherData;

    public void Update()
    {
        float t = weatherData.Temperature;
        float rh = weatherData.Humidity;
        
        heatIndex = (float)(
            (16.923 + (0.185212 * t)) + 
            (5.37941 * rh) - 
            (0.100254 * t * rh) +
            (0.00941695 * (t * t)) + 
            (0.00728898 * (rh * rh)) +
            (0.000345372 * (t * t * rh)) - 
            (0.000814971 * (t * rh * rh)) +
            (0.0000102102 * (t * t * rh * rh)) - 
            (0.000038646 * (t * t * t)) + 
            (0.0000291583 * (rh * rh * rh)) +
            (0.00000142721 * (t * t * t * rh)) +
            (0.000000197483 * (t * rh * rh * rh)) - 
            (0.0000000218429 * (t * t * t * rh * rh)) +
            0.000000000843296 * (t * t * rh * rh * rh)) -
            (0.0000000000481975 * (t * t * t * rh * rh * rh)));
        
        Display();
    }

    public void Display()
    {
        Console.WriteLine($"Heat index is {heatIndex}");
    }
}
```

## Usage Example

```csharp
// Create the subject
WeatherData weatherData = new WeatherData();

// Create observers (they auto-register in constructor)
CurrentConditionsDisplay currentDisplay = new CurrentConditionsDisplay(weatherData);
StatisticsDisplay statisticsDisplay = new StatisticsDisplay(weatherData);
ForecastDisplay forecastDisplay = new ForecastDisplay(weatherData);
HeatIndexDisplay heatIndexDisplay = new HeatIndexDisplay(weatherData);

// Simulate weather measurements
weatherData.SetMeasurements(80, 65, 30.4f);
// All displays automatically update!

weatherData.SetMeasurements(82, 70, 29.2f);
// All displays update again!

weatherData.SetMeasurements(78, 90, 29.2f);
// All displays update once more!
```

## Push vs Pull Models

### Pull Model (Used in this example)

```csharp
public void Update()
{
    this.temperature = weatherData.Temperature;  // Pull from subject
    this.humidity = weatherData.Humidity;
    Display();
}
```

- ✅ **More flexible**: Observers get only what they need
- ✅ **Looser coupling**: Subject doesn't need to know what data observers want
- ❌ **More method calls**: Observers must pull each piece of data

### Push Model (Alternative)

```csharp
public void Update(float temperature, float humidity, float pressure)
{
    this.temperature = temperature;  // Pushed by subject
    this.humidity = humidity;
    Display();
}
```

- ✅ **More efficient**: All data sent in one call
- ❌ **Less flexible**: All observers get same data whether they need it or not
- ❌ **Tighter coupling**: Subject must know what to push

## Benefits of Observer Pattern

✅ **Loose Coupling**:

- Subject and observers are loosely coupled
- Can add/remove observers anytime

✅ **Flexibility**:

- Add new observer types without changing subject
- Mix and match observers at runtime

✅ **Reusability**:

- Subject and observers can be reused independently
- Subject doesn't depend on concrete observers

✅ **Open/Closed Principle**:

- Open for extension (new observers)
- Closed for modification (don't change subject)

✅ **Dynamic Relationships**:

- Register/unregister observers at runtime
- One-to-many dependency

## When to Use Observer Pattern

✅ **Good Use Cases:**

- Event handling systems
- Model-View-Controller (MVC) architecture
- Real-time data feeds (stock prices, weather, sensors)
- Chat systems (one sender, many receivers)
- Notification systems
- Pub/Sub messaging systems

⚠️ **Considerations:**

- **Update order**: Observers notified in sequence, not guaranteed order
- **Performance**: Many observers = more update calls
- **Memory leaks**: Observers must unregister to be garbage collected
- **Unexpected updates**: Chains of updates can be hard to debug

## Real-World Examples

- **UI Event Systems**: Button clicks notify listeners
- **Stock Market**: Price changes notify multiple displays
- **Social Media**: Post notifications to followers
- **RSS Feeds**: New content notifies subscribers
- **Excel**: Cell changes update dependent formulas
- **Game Development**: Events notify game objects

## .NET Built-in Observer Pattern

C# and .NET provide built-in support for Observer Pattern:

### Events and Delegates

```csharp
public class WeatherData
{
    public event EventHandler<WeatherEventArgs> WeatherChanged;
    
    protected virtual void OnWeatherChanged(WeatherEventArgs e)
    {
        WeatherChanged?.Invoke(this, e);
    }
}
```

### IObservable<T> and IObserver<T>

```csharp
public class WeatherData : IObservable<WeatherInfo>
{
    // .NET's built-in observer interfaces
}
```

## Key Takeaways from the Book

1. **The Observer Pattern defines a one-to-many dependency** between objects
2. **Subjects (publishers) update observers (subscribers)** using a common interface
3. **Observers are loosely coupled** - subject doesn't know or care about concrete observer types
4. **You can push or pull data** from the subject
5. **Don't depend on a specific order** of notification to observers
6. **Strive for loosely coupled designs** between objects that interact

## The Book's Wisdom

From Head First Design Patterns:

> "The Observer Pattern defines a one-to-many dependency between objects so that when one object changes state, all of its dependents are notified and updated automatically."

> "Strive for loosely coupled designs between objects that interact. Loosely coupled designs allow us to build flexible OO systems that can handle change because they minimize the interdependency between objects."

> "The Observer Pattern is used all over the place in Java (and .NET)! Even JavaBeans and Swing are based on the Observer Pattern."

## Related Patterns

- **Mediator**: Encapsulates how objects interact; Observer distributes communication
- **Singleton**: Subjects are often Singletons
- **Command**: Can use to implement undo in observers
- **Chain of Responsibility**: Can be combined for event propagation

---

*"The only constant in software development is CHANGE!"* - Head First Design Patterns
