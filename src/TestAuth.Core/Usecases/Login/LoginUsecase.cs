using TestAuth.Core.Services;
using TestAuth.Core.Usecases.Login.Interfaces;
using TestAuth.Core.Usecases.Login.Models;
using TestAuth.Core.Utils.ActionResult;

namespace TestAuth.Core.Usecases.Login;

public class LoginUsecase(ILoginStorage storage, IPasswordService passwordService, IJwtTokenService jwtService)
{
    public async Task<Result<LoginResponse>> Login(LoginRequest request)
    {
        var user = await storage.GetUserByUsername(request.Username);
        if (user == null)
            return Result<LoginResponse>.Invalid().WithMessage("Неверный логин или пароль");

        if (!user.IsActive)
            return Result<LoginResponse>.Invalid().WithMessage("Неверный логин или пароль");

        bool isPasswordValid = passwordService.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt);
        if (!isPasswordValid)
            return Result<LoginResponse>.Invalid().WithMessage("Неверный логин или пароль");

        string token = jwtService.GenerateAcceesToken(new GenerateTokenRequest(user.UserId));
        return Result<LoginResponse>.Success(new LoginResponse(token));
    }
}
