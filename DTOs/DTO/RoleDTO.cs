using q.SQL.Model;

namespace q.DTOs.DTO
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PermissionId { get; set; }
        public PermissionDTO PermissionDTO { get; set; }
    }
}
