using Ch11_TheProxyPattern.Interfaces;
using Ch11_TheProxyPattern.Models;
using Ch11_TheProxyPattern.Proxies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

PrintSection("Chapter 11 - Proxy Pattern");
Console.WriteLine("Scenarios: Remote, Virtual, Protection");

await RunRemoteProxyDemoAsync();
RunVirtualProxyDemo();
RunProtectionProxyDemo();

PrintSection("Summary");
Console.WriteLine("Remote hides network access, virtual defers work, protection gates behavior.");

static async Task RunRemoteProxyDemoAsync()
{
    PrintSection("Remote Proxy (Minimal API)");

    var machineService = new GumballMachineService("Seattle", 5);

    var builder = WebApplication.CreateBuilder();
    builder.WebHost.UseUrls("http://127.0.0.1:5151");
    builder.Logging.ClearProviders();
    builder.Services.AddSingleton(machineService);

    var app = builder.Build();

    app.MapGet("/machine", (GumballMachineService machine) => machine.GetSnapshot());
    app.MapPost("/machine/dispense", (GumballMachineService machine) =>
    {
        machine.InsertQuarterAndTurnCrank();
        return Results.Ok(machine.GetSnapshot());
    });

    await app.StartAsync();

    try
    {
        using var httpClient = new HttpClient { BaseAddress = new Uri("http://127.0.0.1:5151") };

        IGumballMachineRemote machineProxy = new GumballMachineProxy(httpClient);
        var monitor = new GumballMonitor(machineProxy);

        Console.WriteLine("Monitor reads from a proxy as if it were local:");
        Console.WriteLine(monitor.BuildReport());

        await httpClient.PostAsync("/machine/dispense", null);
        Console.WriteLine("After one dispense operation through API:");
        Console.WriteLine(monitor.BuildReport());
    }
    finally
    {
        await app.StopAsync();
        await app.DisposeAsync();
    }
}

static void RunVirtualProxyDemo()
{
    PrintSection("Virtual Proxy (Lazy load)");

    IIcon icon = new ImageProxy("https://example.com/album-cover.jpg");

    Console.WriteLine("Screen paints placeholder before real image is needed.");
    Console.WriteLine("User opens details panel, image now required:");
    Console.WriteLine(icon.Render());
}

static void RunProtectionProxyDemo()
{
    PrintSection("Protection Proxy (Owner vs Non-owner)");

    var person = new PersonBean("Joe Javabean", "Male", "Coding, Music");

    IPersonBean ownerProxy = new OwnerPersonProxy(person);
    IPersonBean nonOwnerProxy = new NonOwnerPersonProxy(person);

    ownerProxy.SetInterests("Coding, Music, Coffee");
    Console.WriteLine($"Owner updated interests: {ownerProxy.Interests}");

    TryAction("Owner tries to set own rating", () => ownerProxy.SetHotOrNotRating(10));

    nonOwnerProxy.SetHotOrNotRating(7);
    Console.WriteLine($"Non-owner set rating. Current rating: {nonOwnerProxy.HotOrNotRating}");

    TryAction("Non-owner tries to edit interests", () => nonOwnerProxy.SetInterests("Hacking"));
}

static void TryAction(string actionName, Action action)
{
    try
    {
        action();
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"{actionName}: blocked ({ex.Message})");
    }
}

static void PrintSection(string title)
{
    Console.WriteLine();
    Console.WriteLine(new string('-', 60));
    Console.WriteLine(title);
    Console.WriteLine(new string('-', 60));
}
