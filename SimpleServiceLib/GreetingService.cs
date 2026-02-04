using System.Dynamic;
using SimpleServiceLib.Tests;

namespace SimpleServiceLib;

public sealed class GreetingService
{
    public GreetingService(ILogService logService)
    {
    }

    public string Greet(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be empty.", nameof(name));
        }

        return $"Hello, {name}!";
    }
}
