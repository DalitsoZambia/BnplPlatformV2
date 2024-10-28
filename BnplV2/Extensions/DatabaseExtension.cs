using BnplV2.Models;
using BnplV2.Modules.Database;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace BnplV2.Extensions;

public static class DatabaseExtension
{
    public static void AddPostgresDb(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionStrings = configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>();
        
        var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionStrings!.Postgres);
        dataSourceBuilder.EnableDynamicJson();
        dataSourceBuilder.RegisterEnumTypeConversion();
        var dataSource = dataSourceBuilder.Build();
        services.AddDbContext<AppDb>(options =>
        {
            options.UseNpgsql(dataSource, optionsBuilder =>
            {
                optionsBuilder.EnableRetryOnFailure();
            });
        });
    }
}