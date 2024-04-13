using MinimalAPi.DTOs.DTO;
using MinimalAPi.SQL.Model;
using q.DTOs.DTO;
using q.SQL.Model;

namespace q.DTOs.Mapping
{
    public static class RoleMapping
    {
        public static Role ToModel(RoleDTO adress)
        {
            if(adress == null)
            {
                return null;
            }
            return new Role
            {
                Name = adress.Name,
                PermissionId = adress.PermissionId,
                Permission = PermissionMapping.ToModel(adress.PermissionDTO)
            };
        }
        public static RoleDTO ToDTO(Role adress)
        {
            if(adress == null)
            {
                return null;
            }
            return new RoleDTO
            {
                Name = adress.Name,
                PermissionId = adress.PermissionId,
                PermissionDTO = PermissionMapping.ToDTO(adress.Permission)
            };
           
        }
        public static IEnumerable<RoleDTO> ToDTOs(this IEnumerable<Role> adress) =>
                  adress.Select(s => ToDTO(s));
    }
}
