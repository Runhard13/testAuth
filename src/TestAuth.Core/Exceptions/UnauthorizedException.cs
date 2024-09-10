using System.Net;

namespace TestAuth.Core.Exceptions;

public class UnauthorizedException(string message) : CustomException(message, HttpStatusCode.Forbidden);
