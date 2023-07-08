using Mackaroni.Shared;

namespace Mackaroni.Client.Impl;

public class BlazorSideProvider : ISideDetector
{
    public bool IsServerSide()
    {
        return false;
    }
}