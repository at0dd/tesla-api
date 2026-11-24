namespace Tests.Support;

using System.Net;
using System.Text;

/// <summary>
/// Records every request and answers it with a canned response, so tests never reach the Tesla API.
/// </summary>
public sealed class StubHttpMessageHandler : HttpMessageHandler
{
    private readonly HttpStatusCode statusCode;
    private readonly string responseJson;

    public StubHttpMessageHandler(string responseJson, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        this.responseJson = responseJson;
        this.statusCode = statusCode;
    }

    public List<RecordedRequest> Requests { get; } = new();

    public RecordedRequest LastRequest => Requests[^1];

    public static (HttpClient Client, StubHttpMessageHandler Handler) CreateClient(string responseJson, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        StubHttpMessageHandler handler = new(responseJson, statusCode);
        return (new HttpClient(handler), handler);
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        string? body = request.Content is null ? null : await request.Content.ReadAsStringAsync(cancellationToken);
        Requests.Add(new RecordedRequest(request.Method, request.RequestUri!, request.Headers.ToDictionary(h => h.Key, h => string.Join(",", h.Value)), body));

        return new HttpResponseMessage(statusCode)
        {
            Content = new StringContent(responseJson, Encoding.UTF8, "application/json"),
        };
    }
}

public sealed record RecordedRequest(HttpMethod Method, Uri Uri, IReadOnlyDictionary<string, string> Headers, string? Body);
