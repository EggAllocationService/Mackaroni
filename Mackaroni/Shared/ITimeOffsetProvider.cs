namespace Mackaroni.Shared;

public interface ITimeOffsetProvider
{
    public Task<int> GetOffsetMinutes();
}