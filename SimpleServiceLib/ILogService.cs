namespace SimpleServiceLib.Tests;

public interface ILogService : IDisposable
{
    bool Initialized { get; }
}