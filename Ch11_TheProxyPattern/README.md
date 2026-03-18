# Chapter 11: The Proxy Pattern

## Pattern Definition

**The Proxy Pattern** provides a surrogate or placeholder for another object to
control access to it.

## The Problem

In the book, the remote example relies on Java RMI. In C#, Java RMI is not
available, but the design problem is still the same:

1. A client should call a local-looking object
2. That object may forward calls across process or network boundaries
3. Client code should not care whether the subject is local or remote

Beyond remote access, the chapter also demonstrates two additional proxy use
cases:

- Delaying expensive object creation (Virtual Proxy)
- Enforcing permissions (Protection Proxy)

## The Solution: Proxy Pattern

The proxy and real subject expose the same abstraction so clients can stay
simple and loosely coupled.

### Proxy Types in This Chapter

1. **Remote Proxy**: forwards calls to a Minimal API endpoint
2. **Virtual Proxy**: creates expensive objects only when needed
3. **Protection Proxy**: allows/blocks operations based on caller role

## Design Principles Applied

### 1. Program to Interfaces

Client code depends on abstractions like `IGumballMachineRemote`, `IIcon`, and
`IPersonBean`.

### 2. Encapsulate What Varies

Network transport, lazy loading, and access control live in proxy classes.

### 3. Open/Closed Principle

New proxy behaviors can be added without changing client classes.

### 4. Single Responsibility

Real subjects focus on domain behavior while proxies manage access strategy.

## Remote Proxy in C# (Minimal API Approach)

### Why Minimal API

Minimal API gives a lightweight replacement for Java RMI while preserving the
same architectural intent.

### Flow

1. `GumballMachineService` is the real remote subject
2. Minimal API exposes machine endpoints (`GET /machine`, `POST /machine/dispense`)
3. `GumballMachineProxy` uses `HttpClient` to call those endpoints
4. `GumballMonitor` depends on `IGumballMachineRemote` only

This reproduces the chapter's monitor behavior with C# tooling.

## Virtual Proxy Example

- `ImageIcon` simulates an expensive object
- `ImageProxy` delays creating `ImageIcon` until first render

This mirrors the chapter's image-loading placeholder pattern.

## Protection Proxy Example

- `OwnerPersonProxy`: can update interests, cannot self-rate
- `NonOwnerPersonProxy`: can rate, cannot edit profile interests

This mirrors owner/non-owner invocation handler behavior from the book.

## Class Diagram (Text)

```
Remote Proxy

┌──────────────────────────────┐
│      IGumballMachineRemote   │
└──────────────────────────────┘
              ▲
              │
┌──────────────────────────────┐         HTTP         ┌──────────────────────────────┐
│      GumballMachineProxy     │ ───────────────────▶ │     GumballMachineService    │
└──────────────────────────────┘                      └──────────────────────────────┘
              ▲
              │ uses
┌──────────────────────────────┐
│        GumballMonitor        │
└──────────────────────────────┘

Virtual Proxy

┌──────────────────────────────┐
│            IIcon             │
└──────────────────────────────┘
             ▲         ▲
             │         │
┌──────────────────────┐   creates lazily   ┌──────────────────────┐
│      ImageProxy      │ ─────────────────▶ │      ImageIcon       │
└──────────────────────┘                    └──────────────────────┘

Protection Proxy

┌──────────────────────────────┐
│          IPersonBean         │
└──────────────────────────────┘
             ▲         ▲         ▲
             │         │         │
┌──────────────────┐ ┌──────────────────┐ ┌──────────────────┐
│    PersonBean    │ │ OwnerPersonProxy │ │ NonOwnerPerson   │
│                  │ │                  │ │ Proxy            │
└──────────────────┘ └──────────────────┘ └──────────────────┘
```

## Program Walkthrough

`Program.cs` runs all examples in sequence:

1. Remote Proxy demo using in-process Minimal API host
2. Virtual Proxy lazy-loading demo
3. Protection Proxy permission checks

Run this chapter:

```powershell
dotnet run --project Ch11_TheProxyPattern/Ch11_TheProxyPattern.csproj
```

## Benefits of Proxy Pattern

✅ Hides remote/network complexity behind a local interface

✅ Defers expensive object creation until needed

✅ Centralizes access-control rules

✅ Keeps client code simple and substitution-friendly

## Project Structure

```
Ch11_TheProxyPattern/
|-- Interfaces/
|   |-- IGumballMachineRemote.cs
|   |-- IIcon.cs
|   `-- IPersonBean.cs
|-- Models/
|   |-- GumballMachineService.cs
|   |-- GumballMachineSnapshot.cs
|   |-- GumballMonitor.cs
|   |-- ImageIcon.cs
|   `-- PersonBean.cs
|-- Proxies/
|   |-- GumballMachineProxy.cs
|   |-- ImageProxy.cs
|   |-- OwnerPersonProxy.cs
|   `-- NonOwnerPersonProxy.cs
|-- Program.cs
`-- README.md
```
