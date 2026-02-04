namespace SimpleServiceLib.Tests;

public abstract class TestContextAware : IContextAware
{
    protected TestContext Context { get; private set; } = null!;

    public void Init(TestContext ctx)
    {
        Context = ctx ?? throw new ArgumentNullException(nameof(ctx));
        OnInit(ctx);
    }

    protected virtual void OnInit(TestContext ctx)
    {
    }
}
