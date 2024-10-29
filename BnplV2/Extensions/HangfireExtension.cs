using Hangfire;
using Hangfire.PostgreSql;

namespace BnplV2.Extensions;

public static class HangfireExtension
{
    public static void AddHangfireCore(this IServiceCollection services)
    {
        services.AddHangfire(configuration => configuration
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UsePostgreSqlStorage(options =>
            {
                options.UseNpgsqlConnection("Host=buy-now-pay-later-uat-db.hobbiton.app;Port=9016;Database=buy-now-pay-later-uat;Username=doadmin;Password=dvih4m8qnc786fge;");
            })
        );
        services.AddHangfireServer();
    }
}