namespace SimpleServiceLib.Tests;

public sealed class TestResultStore
{
    private readonly Dictionary<string, object?> _data = new(StringComparer.Ordinal);

    public T Get<T>(string key)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentException("Key cannot be null or empty.", nameof(key));
        }

        if (!_data.TryGetValue(key, out var value))
        {
            throw new KeyNotFoundException($"No result stored for key '{key}'.");
        }

        if (value is T typed)
        {
            return typed;
        }

        var actualType = value?.GetType().FullName ?? "null";
        throw new InvalidOperationException(
            $"Result '{key}' is not of type {typeof(T).FullName}. Actual: {actualType}.");
    }

    public void Set<T>(string key, T value)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentException("Key cannot be null or empty.", nameof(key));
        }

        _data[key] = value;
    }
}
