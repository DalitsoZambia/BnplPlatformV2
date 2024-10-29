using Microsoft.IdentityModel.Tokens;

namespace BnplV2.Modules.Auth;

public static class LoginValidator
{
    public static List<string> ValidateLogin(LoginRequest request)
    {
        var errors = new List<string>();
        if(request.UserName.IsNullOrEmpty())
            errors.Add("Username is required");
        if(request.Password.IsNullOrEmpty())
            errors.Add("Password is required");

        return errors;
    }
}