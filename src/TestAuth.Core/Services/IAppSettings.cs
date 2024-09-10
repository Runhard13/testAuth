namespace TestAuth.Core.Services;

public interface IAppSettings
{
    AuthSettings AuthSettings { get; init; }
}

public class AuthSettings
{
    public required string ApiSecret { get; init; }
    public required string TokenLifetimeMinutes { get; init; }
}

