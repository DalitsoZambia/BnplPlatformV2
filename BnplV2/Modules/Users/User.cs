using BnplV2.Modules.BaseEntities;

namespace BnplV2.Modules.Users;

public class User: BaseEntity
{
    public string? UserName { get; set; }
    public string? PasswordHash { get; set; }
}

public class UserRequest
{
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }
}

public class UserResponse: BaseEntityResponse
{
    public string? UserName { get; set; }
}

public class UserLoginResponse : BaseEntityResponse
{
    public string? UserName { get; set; } = "";
    public string? PasswordHash { get; set; } = "";
}