using MinimalAPi.DTOs.DTO;
using MinimalAPi.SQL.Model;
using q.DTOs.DTO;
using q.SQL.Model;

namespace q.DTOs.Mapping
{
    public static class PermissionMapping
    {
        public static Permission ToModel(PermissionDTO permission)
        {
            if (permission == null)
            {
                return null; // Or handle the null case appropriately
            }
            return new Permission
            {
                Id = permission.Id,
                PermissionName = permission.PermissionName
                // ZipCode = adress.ZipCode,
            };
        }
        public static PermissionDTO ToDTO(Permission permission)
        {
            if (permission == null)
            {
                return null; // Or handle the null case appropriately
            }
            return new PermissionDTO
            {
                Id = permission.Id,
                PermissionName = permission.PermissionName
            };
        }
        public static IEnumerable<PermissionDTO> ToDTOs(this IEnumerable<Permission> permission) =>
               permission.Select(s => ToDTO(s));
    }
}
