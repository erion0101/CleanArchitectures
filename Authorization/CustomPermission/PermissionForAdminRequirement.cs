using Microsoft.AspNetCore.Authorization;

namespace q.Authorization.CustomPermission
{
    public class PermissionForAdminRequirement : IAuthorizationRequirement
    {
        public string PermissionName { get; }

        public PermissionForAdminRequirement(string permissionName)
        {
            PermissionName = permissionName;
        }
    }
}
