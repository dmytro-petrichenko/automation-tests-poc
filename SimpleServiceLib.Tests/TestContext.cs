namespace SimpleServiceLib.Tests;

public class TestContext : IDisposable
{
    public ILogService LogService { get; }

    public TestResultStore Results { get; } = new();

    public TestContext(ILogService logService)
    {
        LogService = logService ?? throw new ArgumentNullException(nameof(logService));
    }

    public void Dispose()
    {
        LogService.Dispose();
    }
}
