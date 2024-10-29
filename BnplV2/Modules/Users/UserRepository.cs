using BnplV2.Modules.Database;
using BnplV2.Utils;
using BnplV2.Utils.Defaults;
using Microsoft.EntityFrameworkCore;

namespace BnplV2.Modules.Users;

public interface IUserRepository
{
    Task<DefaultResponse<UserResponse>> CreateUserAsync(UserRequest user);
    Task<DefaultResponse<UserLoginResponse>> GetByEmailAsync(string email);
}

public class UserRepository(AppDb db, IPasswordHasher passwordHasher): IUserRepository
{
    public async Task<DefaultResponse<UserResponse>> CreateUserAsync(UserRequest user)
    {
        string? email = null;
        string? password = null;

        if (!string.IsNullOrEmpty(user.Email))
        {
            var existUser = await db.Users.FirstOrDefaultAsync(x => x.UserName!.ToLower().Equals(user.Email.ToLower()));
            if (existUser != null)
                return new DefaultResponse<UserResponse>
                {
                    StatusCode = StatusCodes.Status409Conflict,
                    Message = ResponseMessages.Conflict,
                    Errors = ["User email already in exists in the system"],
                };
            email = user.Email;
        }

        if (!string.IsNullOrEmpty(user.Password))
        {
            if (user.Password != user.ConfirmPassword)
                return new DefaultResponse<UserResponse>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = ResponseMessages.BadRequest,
                    Errors = ["Passwords do not match"],
                };
            password = passwordHasher.HashPassword(user.Password);
        }

        var addedUser = await db.Users.AddAsync(new User
        {
            UserName = email,
            PasswordHash = password
        });
        await db.SaveChangesAsync();

        return new DefaultResponse<UserResponse>
        {
            StatusCode = StatusCodes.Status201Created,
            Message = ResponseMessages.Created,
            Data = new UserResponse
            {
                Id = addedUser.Entity.Id,
                CreatedDate = addedUser.Entity.CreatedDate,
                UpdatedDate = addedUser.Entity.UpdatedDate,
                UserName = addedUser.Entity.UserName,
            }
        };
    }
    public async Task<DefaultResponse<UserLoginResponse>> GetByEmailAsync(string email)
    {
        var user = await db.Users.FirstOrDefaultAsync(x => x.UserName!.ToLower().Equals(email.ToLower()));
        if (user == null)
            return new DefaultResponse<UserLoginResponse>
            {
                StatusCode = StatusCodes.Status404NotFound,
                Message = ResponseMessages.NotFound,
                Errors = ["User not found"],
            };
        
        return new DefaultResponse<UserLoginResponse>
        {
            StatusCode = StatusCodes.Status200OK,
            Message = ResponseMessages.OK,
            Data = new UserLoginResponse
            {
                Id = user.Id,
                CreatedDate = user.CreatedDate,
                UpdatedDate = user.UpdatedDate,
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
            }
        };
    }
}