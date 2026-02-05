namespace SimpleServiceLib.Tests;

public abstract class TestContextAware : IContextAware
{
    protected TestContext Context { get; private set; } = null!;

    public void InitializeContext(TestContext ctx)
    {
        Context = ctx ?? throw new ArgumentNullException(nameof(ctx));
        OnInit();
    }

    protected virtual void OnInit()
    {
    }
}
