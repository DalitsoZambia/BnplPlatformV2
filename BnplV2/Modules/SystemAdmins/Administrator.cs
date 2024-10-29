using BnplV2.Modules.Users;

namespace BnplV2.Modules.SystemAdmins;

public class Administrator: User
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public bool IsActived { get; set; }
}