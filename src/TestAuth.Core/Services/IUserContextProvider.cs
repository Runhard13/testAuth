namespace TestAuth.Core.Services;

public interface IUserContextProvider
{
    UserContextModel GetUserContext();
}

public record UserContextModel(Guid Id);
