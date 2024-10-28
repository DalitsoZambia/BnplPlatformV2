using BnplV2.Modules.BaseEntities;

namespace BnplV2.Modules.Organizations.Entities;


public class OrganizationMember: BaseGroupMember
{
    public double MaxLoanAmount { get; set; } = 0;
    
    public int OrganizationId { get; set; }
    public Organization? Organization { get; set; }
}

public class OrganizationMemberRequest: BaseGroupMemberRequest
{
    public double? MaxLoanAmount { get; set; }
    public int? OrganizationId { get; set; }
}

public class OrganizationMemberResponse: BaseGroupMemberResponse
{
    
}
