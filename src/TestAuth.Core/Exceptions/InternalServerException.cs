namespace TestAuth.Core.Exceptions;

public class InternalServerException(string message) : CustomException(message);
