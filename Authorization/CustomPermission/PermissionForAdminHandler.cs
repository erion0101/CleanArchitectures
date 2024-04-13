using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace q.Authorization.CustomPermission
{
    public class PermissionForAdminHandler : AuthorizationHandler<PermissionForAdminRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionForAdminRequirement requirement)
        {
            if (context.User.HasClaim(c => c.Type == ClaimTypes.Role && c.Value == "admin"))
            {
                if (context.User.HasClaim(c => c.Type == "Permission" && c.Value == requirement.PermissionName))
                {
                    context.Succeed(requirement);
                }
            }
            //MemberAdmin
            return Task.CompletedTask;
        }
    }
}
