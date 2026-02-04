namespace SimpleServiceLib.Tests;

public class GreetingServiceTests 
    : TestsBase<GreetingServiceDriver, GreetingServiceVerifier>
{
    [Test]
    public void Greet_WithName_ReturnsGreeting()
    {
        Driver.MakeGreet("Alice");
        Verifier.AssertSuccessGreetResult();
    }
}

public class GreetingServiceDriver : IContextAware
{
    private TestContext _context = null!;
    private GreetingService _service = null!;

    public void MakeGreet(string name)
    {
        _context.Results.Set("greeting", _service.Greet(name));
    }

    public void Init(TestContext ctx)
    {
        _context = ctx ?? throw new ArgumentNullException(nameof(ctx));
        _service = new GreetingService(ctx.LogService);
    }
}

public class GreetingServiceVerifier : IContextAware
{
    private TestContext _context = null!;

    public void AssertSuccessGreetResult()
    {
        Assert.That("Hello, Alice!", Is.EqualTo(_context.Results.Get<string>("greeting")));
    }

    public void Init(TestContext ctx)
    {
        _context = ctx ?? throw new ArgumentNullException(nameof(ctx));
    }
}
