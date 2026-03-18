using System.Net.Http.Json;
using Ch11_TheProxyPattern.Interfaces;
using Ch11_TheProxyPattern.Models;

namespace Ch11_TheProxyPattern.Proxies;

public sealed class GumballMachineProxy(HttpClient httpClient) : IGumballMachineRemote
{
    private readonly HttpClient _httpClient = httpClient;

    public string Location => GetSnapshot().Location;
    public int Count => GetSnapshot().Count;
    public string State => GetSnapshot().State;

    private GumballMachineSnapshot GetSnapshot()
    {
        var snapshot = _httpClient
            .GetFromJsonAsync<GumballMachineSnapshot>("/machine")
            .GetAwaiter()
            .GetResult();

        return snapshot ?? throw new InvalidOperationException("Could not fetch machine state.");
    }
}
