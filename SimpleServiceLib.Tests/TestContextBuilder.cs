namespace SimpleServiceLib.Tests;

public class TestContextBuilder
{
    private ILogService _logService;

    public TestContextBuilder WithLogService(ILogService logService)
    {
        _logService = logService ?? throw new ArgumentNullException(nameof(logService));
        return this;
    }

    public TestContext Build()
    {
        var service = _logService ?? new DefaultLogService();
        return new TestContext(service);
    }
}