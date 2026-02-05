namespace SimpleServiceLib.Tests;

public class UserServiceTests 
    : TestsBase<UserServiceDriver, UserServiceVerifier>
{
    [Test]
    public void UserLogin_Succeeds_WithValidCredentials()
    {
        // Act
        Driver.LoginUser();

        // Assert
        Verifier.AssertLoginSuccess();
    }
}

public class UserServiceDriver : TestContextAware
{
    private UserService _service = null!;

    public void LoginUser()
    {
        var result = _service.Login("name", "pass");
        Context.Results.Set("loginResult", result);
    }

    protected override void OnInit()
    {
        _service = new UserService(Context.LogService);
    }
}

public class UserServiceVerifier : TestContextAware
{
    public void AssertLoginSuccess()
    {
         var result = Context.Results.Get<string>("loginResult");
         Assert.That(result, Is.EqualTo("ok"));
    }
}
