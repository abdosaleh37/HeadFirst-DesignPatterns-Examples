
# Observer Pattern — Weather App (CH2)

This small example demonstrates the Observer design pattern using a simple weather station. It shows how a subject (`WeatherData`) can notify multiple observers (display elements) about state changes without tight coupling.

Overview
- Intent: Define a one-to-many dependency so changes in one object propagate automatically to many dependents.
- When to use: when multiple objects need to reflect the state of another object, and you want to vary, add, or remove observers at runtime.

Key participants
- `Subject` (here: `WeatherData`): knows and maintains a list of observers; exposes methods to register, remove, and notify observers.
- `Observer` (displays): registers with the subject and implements an `Update(...)` method called when the subject's state changes.
- `ConcreteSubject`: stores state (e.g., temperature, humidity, pressure) and, when state changes, notifies observers.
- `ConcreteObserver`: updates its state based on notifications and often presents data (via `Display()` in this example).

Sequence of interaction (high-level)
1. Observers register with the subject (usually at startup or dynamically at runtime).
2. Subject's state changes (e.g., new sensor readings).
3. Subject calls its notify routine.
4. Notify iterates registered observers and calls their `Update(...)` methods.
5. Each observer pulls necessary data from the notification parameters (push) or directly from the subject (pull), updates itself, and optionally calls `Display()`.

Push vs Pull model
- Push: the subject provides the new state values as parameters to `Update(...)`. Observers get exactly what they need but the subject must know what to send.
- Pull: the subject only signals a change; observers then query the subject for required data. This keeps the subject simpler and more stable when observers need different subsets of data.

C# / implementation notes for this project
- Interfaces: `ISubject`, `IObserver`, and `IDisplayElement` separate responsibilities and make testing easier.
- Registration: use a `List<IObserver>` in the subject to track observers. Consider `IReadOnlyCollection` for exposing lists without allowing external modification.
- Thread-safety: if updates may occur from multiple threads (e.g., sensors), protect the observer list and notifications with locking or use concurrent collections.
- Memory: be careful with long-lived subjects and observers — consider weak references for observers if you want automatic GC of observers that are no longer referenced elsewhere.

Benefits and trade-offs
- Benefits: promotes loose coupling, supports dynamic relationships, and enables many-to-many notification relationships.
- Drawbacks: unpredictable update order, potential performance cost if many observers or heavy updates, and risk of memory leaks if observers aren't removed.

Mapping to this example
- `ISubject`: [CH2_TheObserverPattern_WeatherApp/Interfaces/ISubject.cs](CH2_TheObserverPattern_WeatherApp/Interfaces/ISubject.cs)
- `IObserver`: [CH2_TheObserverPattern_WeatherApp/Interfaces/IObserver.cs](CH2_TheObserverPattern_WeatherApp/Interfaces/IObserver.cs)
- `WeatherData` (ConcreteSubject): [CH2_TheObserverPattern_WeatherApp/Models/WeatherData.cs](CH2_TheObserverPattern_WeatherApp/Models/WeatherData.cs)
- Displays (ConcreteObservers): `CurrentConditionsDisplay`, `StatisticsDisplay`, `ForecastDisplay`, `HeatIndexDisplay`, `ThirdPartyDisplay` in [CH2_TheObserverPattern_WeatherApp/Models](CH2_TheObserverPattern_WeatherApp/Models)

Extending the example
- Add observers that subscribe/unsubscribe at runtime to simulate components appearing/disappearing.
- Implement a prioritized notification list or filter so only interested observers receive certain updates.
- Experiment with converting push notifications to pull to support observers needing additional context.

Running the example
From the workspace root run:

```powershell
dotnet run --project CH2_TheObserverPattern_WeatherApp
```

Further reading
- "Design Patterns: Elements of Reusable Object-Oriented Software" — Observer pattern.
- Head First Design Patterns — chapter on Observer (this example).

