using System.Dynamic;
using SimpleServiceLib.Tests;

namespace SimpleServiceLib;

public sealed class UserService
{
    private readonly ILogService _logService;

    public UserService(ILogService logService)
    {
        _logService = logService;
    }

    public string Login(string username, string password)
    {
        return "ok";
    }
}
