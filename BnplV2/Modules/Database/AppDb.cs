using BnplV2.Extensions;
using BnplV2.Modules.BaseEntities;
using BnplV2.Modules.Organizations.Entities;
using BnplV2.Modules.SystemAdmins;
using BnplV2.Modules.Users;
using Microsoft.EntityFrameworkCore;

namespace BnplV2.Modules.Database;

public class AppDb(DbContextOptions<AppDb> options): DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.MapPostgresEnums();
        builder.Entity<BaseGroupMember>().UseTpcMappingStrategy();
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Administrator> Admins { get; set; }
    public DbSet<OrganizationMember> OrganizationMembers { get; set; }
}