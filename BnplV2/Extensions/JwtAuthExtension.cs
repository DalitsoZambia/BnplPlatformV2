using System.Text;
using BnplV2.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace BnplV2.Extensions;

public static class JwtAuthExtension
{
    public static void AddJwtBearerAuth(this IServiceCollection service, IConfiguration configuration)
    {
        var jwt = configuration.GetSection("Jwt").Get<Jwt>();
        service.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwt!.Key)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateActor = false
                };
            });
    }
}