# Chapter 2 — Observer Pattern

> *"Define a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically."*  
> — Design Patterns: Elements of Reusable Object-Oriented Software

## Intent

Observer decouples state producers from state consumers by defining a subscription contract. In this chapter, `WeatherData` publishes measurement changes, while display elements subscribe and update independently. The publisher does not need compile-time knowledge of specific display implementations.

## Also Known As

Dependents, Publish-Subscribe.

## Motivation

The weather station has evolving display requirements: current conditions, forecast, statistics, heat index, and potentially third-party modules. Hard-coding direct calls from `WeatherData` to each display creates brittle coupling and forces source edits for every new display type.

Observer centralizes change notification (`NotifyObservers`) and lets each display decide how to react, enabling extension without modifying `WeatherData`.

## Chapter Summary (From the Book)

Chapter 2 starts with a tightly coupled weather station where the data source directly updates concrete displays. That approach looks straightforward initially but quickly breaks under changing requirements: adding/removing displays, reordering updates, and integrating third-party views all require modifying the publisher.

The chapter reframes the problem as a one-to-many relationship: one subject changes, many dependents must stay synchronized. The key design goal becomes **loose coupling** between the source of truth and UI consumers.

The Observer solution introduces a subject interface for registration/removal/notification and an observer interface for update callbacks. `WeatherData` only knows observers abstractly, while displays pull needed values and render themselves.

Core takeaway: **design for independent evolution of publishers and subscribers**.

## Applicability

- A change in one object should trigger updates in many others.
- Dependents must be pluggable at runtime.
- You need extension points for third-party consumers.
- You want to avoid direct dependency from publisher to concrete listeners.

## Structure

```text
ISubject <- WeatherData -> IObserver
                          +- CurrentConditionsDisplay
                          +- StatisticsDisplay
                          +- ForecastDisplay
                          +- HeatIndexDisplay
                          +- ThirdPartyDisplay
```

## Participants

| Role | Class in This Project | Responsibility |
|---|---|---|
| Subject | `WeatherData` | Stores measurements, keeps observer list, triggers notifications |
| Observer | `IObserver` | Declares `Update()` for change callbacks |
| Concrete Observer | `CurrentConditionsDisplay`, `StatisticsDisplay`, `ForecastDisplay`, `HeatIndexDisplay`, `ThirdPartyDisplay` | Pulls weather data and computes display output |
| Display Abstraction | `IDisplayElement` | Keeps rendering concern explicit and consistent |
| Client | `Program` | Wires subject and observers, then pushes sample measurement updates |

## Collaborations

1. Client constructs `WeatherData` and display observers.
2. Each observer registers itself with subject during construction.
3. Client calls `SetMeasurements(...)` on subject.
4. Subject updates internal state and invokes `NotifyObservers()`.
5. Each observer pulls relevant state and prints its own view.

## Consequences

**Benefits**

- Publisher and subscribers evolve independently.
- New displays can be added with no publisher code changes.
- Runtime registration/removal supports dynamic composition.
- Natural fit for event-driven design.

**Liabilities**

- Notification ordering may matter and can be non-obvious.
- Large observer sets can cause update storms.
- Debugging cascaded updates can be harder than direct calls.

## Implementation Notes

- This implementation uses pull-style updates (`Update()` then read properties from `WeatherData`).
- Observer registration is explicit in constructors.
- `WeatherData` exposes `Temperature`, `Humidity`, and `Pressure` as read-only properties.
- A push variant could pass values directly into `Update(...)` if needed.

## Sample Code

```csharp
var weatherData = new WeatherData();
_ = new CurrentConditionsDisplay(weatherData);
_ = new ForecastDisplay(weatherData);

weatherData.SetMeasurements(80, 65, 30.4f);
```

## Known Uses

- .NET events and delegates (`event`, `EventHandler<T>`).
- Reactive streams via `IObservable<T>` / `IObserver<T>`.
- UI data binding and notification pipelines.

## Related Patterns

- **Mediator**: coordinates many-to-many communication through a central object.
- **Singleton**: sometimes used when one shared subject instance is required.
- **Model-View-Controller**: commonly uses Observer between model and views.

## Project File Map

```text
Ch02_TheObserverPattern/
+- Program.cs
+- Ch02_TheObserverPattern.csproj
+- Interfaces/
|  +- ISubject.cs
|  +- IObserver.cs
|  +- IDisplayElement.cs
+- Models/
   +- WeatherData.cs
   +- CurrentConditionsDisplay.cs
   +- StatisticsDisplay.cs
   +- ForecastDisplay.cs
   +- HeatIndexDisplay.cs
   +- ThirdPartyDisplay.cs
```

## How to Run

`dotnet run --project Ch02_TheObserverPattern/Ch02_TheObserverPattern.csproj`
