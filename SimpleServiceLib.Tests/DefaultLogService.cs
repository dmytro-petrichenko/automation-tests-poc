namespace SimpleServiceLib.Tests;

public class DefaultLogService : ILogService
{
    public void Dispose()
    {
    }

    public bool Initialized { get; }
}