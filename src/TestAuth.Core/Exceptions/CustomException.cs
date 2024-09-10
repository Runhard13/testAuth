using System.Net;

namespace TestAuth.Core.Exceptions;

public class CustomException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : Exception(message)
{
    public HttpStatusCode StatusCode { get; } = statusCode;
}
