using BnplV2.Modules.Organizations.Entities;
using BnplV2.Utils.Defaults;

namespace BnplV2.Modules.Organizations;

public interface IOrganizationRepository
{
    Task<DefaultResponse<OrganizationResponse>> CreateOrganizationAsync(OrganizationRequest organization);
    Task<DefaultResponse<OrganizationMemberResponse>> CreateOrganizationMemberAsync(OrganizationMemberRequest organizationMember);
    Task<DefaultResponse<OrganizationMemberResponse>> EnableOrganizationMemberAsync(int memberId);
    Task<DefaultResponse<OrganizationMemberResponse>> DisableOrganizationMemberAsync(int memberId);
}


public class OrganizationRepository: IOrganizationRepository
{
    public async Task<DefaultResponse<OrganizationResponse>> CreateOrganizationAsync(OrganizationRequest organization)
    {
        throw new NotImplementedException();
    }

    public Task<DefaultResponse<OrganizationMemberResponse>> CreateOrganizationMemberAsync(OrganizationMemberRequest organizationMember)
    {
        throw new NotImplementedException();
    }

    public Task<DefaultResponse<OrganizationMemberResponse>> EnableOrganizationMemberAsync(int memberId)
    {
        throw new NotImplementedException();
    }

    public Task<DefaultResponse<OrganizationMemberResponse>> DisableOrganizationMemberAsync(int memberId)
    {
        throw new NotImplementedException();
    }
}