namespace SimpleServiceLib.Tests;

public abstract class TestContextAware : IContextAware
{
    protected TestContext Context { get; private set; } = null!;

    public void InitializeContext(TestContext context)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
        OnInit();
    }

    protected virtual void OnInit()
    {
    }
}
