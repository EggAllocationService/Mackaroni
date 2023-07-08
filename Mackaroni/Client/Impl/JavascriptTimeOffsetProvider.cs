using Mackaroni.Shared;
using Microsoft.JSInterop;

namespace Mackaroni.Client.Impl;

public class JavascriptTimeOffsetProvider : ITimeOffsetProvider
{
    private IJSRuntime _jsRuntime;
    public JavascriptTimeOffsetProvider(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }
    public async Task<int> GetOffsetMinutes()
    {
        return await _jsRuntime.InvokeAsync<int>("GetDateTimeOffset");
    }
}