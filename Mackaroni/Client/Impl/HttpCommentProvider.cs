using System.Net.Http.Json;
using Mackaroni.Shared;

namespace Mackaroni.Client.Impl;

public class HttpCommentProvider : ICommentThreadProvider
{
    private HttpClient _client;
    public HttpCommentProvider(HttpClient client)
    {
        _client = client;
    }
    public async Task<List<Comment>> GetCommentsForPage(string page)
    {
        return await _client.GetFromJsonAsync<List<Comment>>("/api/comments/" + page);
    }
}