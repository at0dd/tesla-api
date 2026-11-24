namespace Tests.Unit;

using TeslaAPI;

/// <summary>
/// One API method, and the HTTP request it should send.
/// </summary>
/// <param name="Name">The test's display name.</param>
/// <param name="Call">Calls the API method.</param>
/// <param name="Method">The expected HTTP method.</param>
/// <param name="Url">The expected absolute URL.</param>
/// <param name="Body">The expected JSON body, or null when the request has none.</param>
/// <param name="ResponseJson">The canned response the stub returns.</param>
public sealed record EndpointCase(
    string Name,
    Func<ITeslaAPI, HttpClient, Task> Call,
    HttpMethod Method,
    string Url,
    string? Body = null,
    string ResponseJson = """{"response":null}""")
{
    public override string ToString() => Name;
}
