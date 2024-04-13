using System.ComponentModel.DataAnnotations.Schema;

namespace q.SQL.Model
{
    [Table("Permission")]
    public class Permission : BaseViewModel
    {
        [Column("PermissionName")]
        public string PermissionName { get; set; }
    }
}
