using Ch11_TheProxyPattern.Interfaces;
using Ch11_TheProxyPattern.Models;
using Ch11_TheProxyPattern.Proxies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

// -----------------------------------------------------------------------------
//  CHAPTER 11 - THE PROXY PATTERN
// -----------------------------------------------------------------------------
PrintHeader("CHAPTER 11 - THE PROXY PATTERN", '=');
Console.WriteLine(
    """
    The Proxy Pattern provides a surrogate or placeholder for another object
    to control access to it.

    This chapter demonstrates:
      1. Remote Proxy (Minimal API + HttpClient)
      2. Virtual Proxy (lazy loading)
      3. Protection Proxy (owner vs non-owner permissions)
    """);

await RunRemoteProxyDemoAsync();
RunVirtualProxyDemo();
RunProtectionProxyDemo();

PrintHeader("SUMMARY", '=');
Console.WriteLine(
    """
    Key takeaways:
      - Remote Proxy hides network boundaries behind a local interface.
      - Virtual Proxy delays expensive creation until it is needed.
      - Protection Proxy enforces rules before allowing operations.
    """);

static async Task RunRemoteProxyDemoAsync()
{
    PrintHeader("PART 1: Remote Proxy (Minimal API)", '-');

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
    PrintHeader("PART 2: Virtual Proxy", '-');

    IIcon icon = new ImageProxy("https://example.com/album-cover.jpg");

    Console.WriteLine("Screen paints placeholder before real image is needed.");
    Console.WriteLine("User opens details panel, image now required:");
    Console.WriteLine(icon.Render());
}

static void RunProtectionProxyDemo()
{
    PrintHeader("PART 3: Protection Proxy", '-');

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

static void PrintHeader(string title, char separator)
{
    string line = new string(separator, 79);
    Console.WriteLine();
    Console.WriteLine(line);
    Console.WriteLine($"  {title}");
    Console.WriteLine(line);
}
