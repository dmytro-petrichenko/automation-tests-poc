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

public class GreetingServiceDriver : TestContextAware
{
    private GreetingService _service = null!;

    public void MakeGreet(string name)
    {
        Context.Results.Set("greeting", _service.Greet(name));
    }

    protected override void OnInit(TestContext ctx)
    {
        _service = new GreetingService(ctx.LogService);
    }
}

public class GreetingServiceVerifier : TestContextAware
{
    public void AssertSuccessGreetResult()
    {
        Assert.That("Hello, Alice!", Is.EqualTo(Context.Results.Get<string>("greeting")));
    }
}
