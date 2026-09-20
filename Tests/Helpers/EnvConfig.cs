namespace Tests.Helpers;

public static class EnvConfig
{
    private static readonly Dictionary<string, string> Values = Load();

    private static string EnvironmentName => Get("ENVIRONMENT_NAME");
    public static string Email => Get($"EMAIL_{EnvironmentName}");
    public static string Password => Get($"PASSWORD_{EnvironmentName}");

    private static string Get(string key)
    {
        if (!Values.TryGetValue(key, out var value) || string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidOperationException(
                $"Missing '{key}' value. Check that it is set in the .env file.");
        }

        return value;
    }

    private static Dictionary<string, string> Load()
    {
        var values = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        var envPath = FindEnvFile();
        if (envPath is null)
        {
            return values;
        }

        foreach (var rawLine in File.ReadAllLines(envPath))
        {
            var line = rawLine.Trim();
            if (line.Length == 0 || line.StartsWith('#'))
            {
                continue;
            }

            var separatorIndex = line.IndexOf('=');
            if (separatorIndex <= 0)
            {
                continue;
            }

            var key = line[..separatorIndex].Trim();
            var value = line[(separatorIndex + 1)..].Trim().Trim('"');
            values[key] = value;
        }

        return values;
    }

    private static string? FindEnvFile()
    {
        var directory = new DirectoryInfo(AppContext.BaseDirectory);
        while (directory is not null)
        {
            var candidate = Path.Combine(directory.FullName, ".env");
            if (File.Exists(candidate))
            {
                return candidate;
            }

            directory = directory.Parent;
        }

        return null;
    }
}
