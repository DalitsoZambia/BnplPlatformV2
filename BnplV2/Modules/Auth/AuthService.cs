using BnplV2.Modules.Database;
using BnplV2.Modules.Users;
using BnplV2.Utils;
using BnplV2.Utils.Defaults;
using Microsoft.EntityFrameworkCore;

namespace BnplV2.Modules.Auth;

public interface IAuthService
{
    Task<DefaultResponse<LoginResponse>> LoginAdminAsync(LoginRequest request);
    Task<DefaultResponse<LoginResponse>> LoginOrganizationMemberAsync(LoginRequest request);
    Task<DefaultResponse<LoginResponse>> LoginMicrofinMemberAsync(LoginRequest request);
}

public class AuthService(IPasswordHasher passwordHasher, IUserRepository userRepository, AppDb db): IAuthService
{
    private async Task<DefaultResponse<UserResponse>> VerifyUserAsync(LoginRequest request)
    {
        var errors = LoginValidator.ValidateLogin(request);
        if (errors.Count > 0)
            return new DefaultResponse<UserResponse>
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = ResponseMessages.BadRequest,
                Errors = errors,
            };
        var userResponse = await userRepository.GetByEmailAsync(request.UserName!);
        if (userResponse.StatusCode == StatusCodes.Status404NotFound)
            return new DefaultResponse<UserResponse>
            {
                StatusCode = userResponse.StatusCode,
                Message = userResponse.Message,
                Errors = userResponse.Errors,
            };

        var isVerifiedPassword = passwordHasher.VerifyPassword(request.Password!, userResponse.Data!.PasswordHash!);
        if (isVerifiedPassword == false)
            return new DefaultResponse<UserResponse>
            {
                StatusCode = StatusCodes.Status404NotFound,
                Message = ResponseMessages.NotFound,
                Errors = ["Username / Password combination was not found"],
            };
        return new DefaultResponse<UserResponse>
        {
            StatusCode = StatusCodes.Status200OK,
            Message = ResponseMessages.OK,
            Data = new UserResponse
            {
                Id = userResponse.Data.Id,
                CreatedDate = userResponse.Data.CreatedDate,
                UpdatedDate = userResponse.Data.CreatedDate,
                UserName = userResponse.Data?.UserName,
            },
        };
    }
    public async Task<DefaultResponse<LoginResponse>> LoginAdminAsync(LoginRequest request)
    {
        var verifiedUserResponse = await VerifyUserAsync(request);
        if (verifiedUserResponse.StatusCode != StatusCodes.Status200OK)
            return new DefaultResponse<LoginResponse>
            {
                StatusCode = verifiedUserResponse.StatusCode,
                Message = verifiedUserResponse.Message,
                Errors = verifiedUserResponse.Errors,
            };

        var admin = await db.Admins
            .Where(x => x.User.Id == verifiedUserResponse.Data!.Id)
            .Where(x => x.IsActived)
            .FirstOrDefaultAsync();

        if (admin == null)
            return new DefaultResponse<LoginResponse>
            {
                StatusCode = StatusCodes.Status404NotFound,
                Message = ResponseMessages.NotFound,
                Errors = ["Admin is not activated. Please activate your admin account."],
            };
        
        //Create JWT Token and return 
        return new DefaultResponse<LoginResponse>
        {
            StatusCode = StatusCodes.Status200OK,
            Message = ResponseMessages.OK,
            Data = new LoginResponse
            {
                Token = $"null",
                RefreshToken = $"null"
            }
        };
    }
    public Task<DefaultResponse<LoginResponse>> LoginOrganizationMemberAsync(LoginRequest request)
    {
        throw new NotImplementedException();
    }
    public Task<DefaultResponse<LoginResponse>> LoginMicrofinMemberAsync(LoginRequest request)
    {
        throw new NotImplementedException();
    }
}