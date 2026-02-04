namespace SimpleServiceLib.Tests;

public class TestContext : IDisposable
{
    public ILogService LogService { get; }
    
    public object ActionResult { get; set;  }

    public TestContext(ILogService logService)
    {
        LogService = logService ?? throw new ArgumentNullException(nameof(logService));
    }

    public T GetActionResult<T>()
    {
        if (ActionResult is T typed)
        {
            return typed;
        }

        var actualType = ActionResult?.GetType().FullName ?? "null";
        throw new InvalidOperationException(
            $"ActionResult is not of type {typeof(T).FullName}. Actual: {actualType}.");
    }

    public void Dispose()
    {
        LogService.Dispose();
    }
}
