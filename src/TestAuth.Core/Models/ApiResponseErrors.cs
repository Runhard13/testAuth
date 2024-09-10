namespace TestAuth.Core.Models;

public class ApiResponseErrors
{
    public string Message { get; init; } = string.Empty;
    public List<string> Descriptions { get; init; } = [];
}

