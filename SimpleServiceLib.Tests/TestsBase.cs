namespace SimpleServiceLib.Tests;

public interface IContextAware
{
    void Init(TestContext ctx);
}

public abstract class TestsBase<TDriver, TVerifier>
    where TDriver : class, IContextAware, new()
    where TVerifier : class, IContextAware, new()
{
    protected TestContext Context { get; private set; }
    protected TDriver Driver { get; private set; }
    protected TVerifier Verifier { get; private set; }

    [SetUp]
    public void BaseSetUp()
    {
        Context = BuildContext();
        Driver = CreateDriver(Context);
        Verifier = CreateVerifier(Context);
    }

    [TearDown]
    public void BaseTearDown()
    {
        Context?.Dispose();
    }
    
    protected virtual TestContext BuildContext()
    {
        return new TestContextBuilder().Build();
    }

    protected virtual TDriver CreateDriver(TestContext ctx)
    {
        var driver = new TDriver();
        driver.Init(ctx);
        return driver;
    }

    protected virtual TVerifier CreateVerifier(TestContext ctx)
    {
        var verifier = new TVerifier();
        verifier.Init(ctx);
        return verifier;
    }
}
