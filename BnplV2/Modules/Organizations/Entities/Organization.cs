using BnplV2.Modules.BaseEntities;
using BnplV2.Modules.Users;

namespace BnplV2.Modules.Organizations.Entities;

public class Organization: BaseEntity
{
    public required string Name { get; set; }
    public required string RegistrationNumber { get; set; }
    public required string ContactNumber { get; set; }
    public required string Email { get; set; }
    public required string Address { get; set; }
    public List<OrganizationMember> OrganizationMembers { get; set; } = [];
    
    public int CreatedById { get; set; }
    public User? CreatedBy { get; set; }
}

public class OrganizationRequest
{
    public string? Name { get; set; }
    public string? RegistrationNumber { get; set; }
    public string? ContactNumber { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public OrganizationMemberRequest? Admin { get; set; }
}

public class OrganizationResponse: BaseEntityResponse
{
    public string Name { get; set; } = String.Empty;
    public string RegistrationNumber { get; set; } = String.Empty;
    public string ContactNumber { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string Address { get; set; } = String.Empty;
    public List<OrganizationMemberResponse> Members { get; set; } = [];
}