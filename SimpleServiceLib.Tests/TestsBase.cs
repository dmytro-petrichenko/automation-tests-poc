namespace SimpleServiceLib.Tests;

public abstract class TestsBase<TDriver, TVerifier>
    where TDriver : class, new()
    where TVerifier : class, new()
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
        return new TDriver();
    }

    protected virtual TVerifier CreateVerifier(TestContext ctx)
    {
        return new TVerifier();
    }
}
