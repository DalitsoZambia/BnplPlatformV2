using BnplV2.Modules.Organizations;
using BnplV2.Modules.Organizations.Entities;
using BnplV2.Utils;
using BnplV2.Utils.Defaults;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BnplV2.Modules.Admin;

[ApiController, Route(RoutesV1.Admins)]
public class AdminController: ControllerBase
{
    [HttpPost("organizations")]
    [SwaggerOperation("Create an organization")]
    public IActionResult CreateOrganization(OrganizationRequest organization)
    {
        var organizationErrors = OrganizationValidator.ValidateOrganizationRequest(organization);
        var adminErrors = OrganizationValidator.ValidateOrganizationMemberRequest(organization.Admin!);
        var errors = organizationErrors.Concat(adminErrors).ToList();
        
        if(errors.Count > 0) 
            return BadRequest(
                new DefaultResponse<string>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = ResponseMessages.BadRequest,
                    Errors = errors,
                }
            );


        return Ok(new DefaultResponse<OrganizationResponse>
        {
            StatusCode = 0,
            Message = null,
            Errors = null,
            Data = null
        });
    }
}