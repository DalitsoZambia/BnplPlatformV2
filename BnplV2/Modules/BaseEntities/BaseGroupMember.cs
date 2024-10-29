using BnplV2.EnumTypes;
using BnplV2.Modules.Users;

namespace BnplV2.Modules.BaseEntities;

public abstract  class BaseGroupMember: User
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public required string ManNumber { get; set; }
    public required string IdNumber { get; set; }
    public required IdType IdType { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsActivated { get; set; }
    public required string Position { get; set; }
    public string? IdUrl { get; set; }
    
    public int CreatedById { get; set; }
    public User? CreatedBy { get; set; }
}

public class BaseGroupMemberRequest
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? ManNumber { get; set; }
    public string? IdNumber { get; set; }
    public IdType? IdType { get; set; }
    public bool? IsAdmin { get; set; }
    public bool? IsActivated { get; set; }
    public string? Position { get; set; }
}

public class BaseGroupMemberResponse
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? ManNumber { get; set; }
    public string? IdNumber { get; set; }
    public IdType IdType { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsActivated { get; set; }
    public string? Position { get; set; }
    public string? IdUrl { get; set; }
    public int CreatedById { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset LastUpdated { get; set; }
}