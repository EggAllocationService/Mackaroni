using Mackaroni.Shared;

namespace Mackaroni.Server.Impl;

public class ServerSideProvider : ISideDetector
{
    public bool IsServerSide()
    {
        return true;
    }
}