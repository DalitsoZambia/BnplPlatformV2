using BnplV2.Modules.Organizations;
using BnplV2.Modules.Users;
using BnplV2.Utils;

namespace BnplV2.Extensions;

public static class AppServicesExtension
{
    public static void AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<IOrganizationService, OrganizationService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddSingleton<IPasswordHasher, PasswordHasher>();
    }


    public static void AddAppRepositories(this IServiceCollection services)
    {
        services.AddScoped<IOrganizationRepository, OrganizationRepository>();
    }
}