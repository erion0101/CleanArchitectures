using Microsoft.AspNetCore.Authorization;
using q.DTOs.DTO;

namespace q.Authorization
{
    public class AdminRequirement : IAuthorizationRequirement
    {
        public string RoleName { get; }
        public AdminRequirement(string roleName)
         {
            RoleName = roleName;
        }

        
    }
}
