namespace SimpleServiceLib.Tests;

public class GreetingServiceTests 
    : TestsBase<GreetingServiceDriver, GreetingServiceVerifier>
{
    protected override GreetingServiceDriver CreateDriver(TestContext ctx)
    {
        return new GreetingServiceDriver(ctx);
    }

    protected override GreetingServiceVerifier CreateVerifier(TestContext ctx)
    {
        return new GreetingServiceVerifier(ctx);
    }

    [Test]
    public void Greet_WithName_ReturnsGreeting()
    {
        Driver.MakeGreet("Alice");
        Verifier.AssertSuccessGreetResult();
    }
}

public class GreetingServiceDriver
{
    private TestContext _context = null!;
    private GreetingService _service = null!;

    public GreetingServiceDriver()
    {
    }

    public GreetingServiceDriver(TestContext context)
    {
        _context = context;
        _service = new GreetingService(context.LogService);
    }

    public void MakeGreet(string name)
    {
        _context.ActionResult = _service.Greet(name);
    }
}

public class GreetingServiceVerifier
{
    private TestContext _context = null!;

    public GreetingServiceVerifier()
    {
    }
    
    public GreetingServiceVerifier(TestContext context)
    {
        _context = context;
    }

    public void AssertSuccessGreetResult()
    {
        Assert.That("Hello, Alice!", Is.EqualTo(_context.GetActionResult<string>()));
    }
}
