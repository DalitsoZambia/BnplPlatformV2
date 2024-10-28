using System.Reflection;
using BnplV2.Attributes;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace BnplV2.Extensions;

public static class EnumTypesExtension
{
    public static void MapPostgresEnums(this ModelBuilder builder)
    {
        var postgresEnums = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => x.GetCustomAttribute<PostgresEnumAttribute>() != null)
            .ToList();
        
        foreach (var postgresEnum in postgresEnums)
        {
            builder.HasPostgresEnum(postgresEnum.Name, postgresEnum.GetEnumNames().Select(x => x.Underscore()).ToArray());
        }
    }
    
    public static void RegisterEnumTypeConversion(this NpgsqlDataSourceBuilder builder)
    {
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => x.GetCustomAttribute<PostgresEnumAttribute>() != null)
            .ToList();

        foreach (var type in types)
        {
            builder.MapEnum(type, type.Name);
        }
    }
}