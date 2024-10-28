using BnplV2.Modules.Organizations.Entities;
using BnplV2.Utils.Defaults;

namespace BnplV2.Modules.Organizations;

public interface IOrganizationService
{
    Task<DefaultResponse<OrganizationResponse>> CreateAsync(OrganizationRequest organization);
}

public class OrganizationService: IOrganizationService
{
    public async Task<DefaultResponse<OrganizationResponse>> CreateAsync(OrganizationRequest organization)
    {
        throw new NotImplementedException();
    }
}