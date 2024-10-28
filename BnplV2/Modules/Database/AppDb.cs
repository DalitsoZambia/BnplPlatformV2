using BnplV2.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BnplV2.Modules.Database;

public class AppDb(DbContextOptions<AppDb> options): DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.MapPostgresEnums();
    }
}