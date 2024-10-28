using BnplV2.Modules.Organizations.Entities;

namespace BnplV2.Modules.Organizations;

public static class OrganizationValidator
{
    public static List<string> ValidateOrganizationRequest(OrganizationRequest organization)
    {
        List<string> errors = [];
        
        if(organization.Email == null)
            errors.Add("Email is required");
        if(organization.Name == null)
            errors.Add("Name is required");
        if(organization.ContactNumber == null)
            errors.Add("Contact number is required");
        if(organization.RegistrationNumber == null)
            errors.Add("Registration number is required");
        if(organization.Address == null)
            errors.Add("Address is required");
        if(organization.Admin == null)
            errors.Add("Admin is required");
        return errors;
    }


    public static List<string> ValidateOrganizationMemberRequest(OrganizationMemberRequest request)
    {
        List<string> errors = [];
        if(request.FirstName == null)
            errors.Add("First name is required");
        if(request.LastName == null)
            errors.Add("Last name is required");
        if(request.OrganizationId == null)
            errors.Add("Organization Id is required");
        if(request.Position == null)
            errors.Add("Position is required");
        if(request.IdType == null)
            errors.Add("Id Type is required");
        if(request.IdNumber == null)
            errors.Add("Id Number is required");
        if(request.PhoneNumber == null)
            errors.Add("Phone Number is required");
        if(request.IsAdmin == null)
            errors.Add("Select whether user is an admin or not");
        if(request.IsActivated == null)
            errors.Add("select whether user is activate or not");
        if(request.MaxLoanAmount == null)
            errors.Add("Max Loan Amount is required");
        if(request.ManNumber == null)
            errors.Add("Man number for employee is required");
        if(request.Email == null && request.IsAdmin == true)
            errors.Add("Admins should provide a valid email address");
        
        return errors;
    }
}