using Mackaroni.Shared;

namespace Mackaroni.Server.Impl;

public class DummyTimeOffsetProvider : ITimeOffsetProvider
{
    public Task<int> GetOffsetMinutes()
    {
        return Task.FromResult(0);
    }
}