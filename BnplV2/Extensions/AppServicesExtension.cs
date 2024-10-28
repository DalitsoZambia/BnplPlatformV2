using BnplV2.Modules.Organizations;

namespace BnplV2.Extensions;

public static class AppServicesExtension
{
    public static void AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<IOrganizationService, OrganizationService>();
    }


    public static void AddAppRepositories(this IServiceCollection services)
    {
        services.AddScoped<IOrganizationRepository, OrganizationRepository>();
    }
}