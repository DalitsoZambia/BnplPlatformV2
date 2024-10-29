using BnplV2.Modules.Users;
using BnplV2.Utils;
using BnplV2.Utils.Defaults;

namespace BnplV2.Modules.Auth;

public interface IAuthService
{
    Task<DefaultResponse<LoginResponse>> LoginAsync(LoginRequest request);
}

public class AuthService(IPasswordHasher passwordHasher, IUserRepository userRepository): IAuthService
{
    public async Task<DefaultResponse<LoginResponse>> LoginAsync(LoginRequest request)
    {
        var errors = LoginValidator.ValidateLogin(request);
        if (errors.Count > 0)
            return new DefaultResponse<LoginResponse>
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = ResponseMessages.BadRequest,
                Errors = errors,
            };
        var userResponse = await userRepository.GetByEmailAsync(request.UserName!);
        if (userResponse.StatusCode == StatusCodes.Status404NotFound)
            return new DefaultResponse<LoginResponse>
            {
                StatusCode = userResponse.StatusCode,
                Message = userResponse.Message,
                Errors = userResponse.Errors,
            };

        var isVerifiedPassword = passwordHasher.VerifyPassword(request.Password!, userResponse.Data!.PasswordHash!);
        if (isVerifiedPassword == false)
            return new DefaultResponse<LoginResponse>
            {
                StatusCode = StatusCodes.Status404NotFound,
                Message = ResponseMessages.NotFound,
                Errors = ["Username / Password combination was not found"],
            };
        return new DefaultResponse<LoginResponse>
        {
            StatusCode = StatusCodes.Status200OK,
            Message = ResponseMessages.OK,
            Data = new LoginResponse
            {
                Token = "",
                RefreshToken = ""
            }
        };
    }
}