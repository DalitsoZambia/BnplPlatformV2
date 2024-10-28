using BnplV2.Modules.BaseEntities;

namespace BnplV2.Modules.Users;

public class User: BaseEntity
{
    public string? Username { get; set; }
    public string? PasswordHash { get; set; }
}