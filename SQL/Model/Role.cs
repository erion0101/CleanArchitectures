using System.ComponentModel.DataAnnotations.Schema;

namespace q.SQL.Model
{
    [Table("Roles")]
    public class Role : BaseViewModel
    {
        [Column("Name")]
        public string Name { get; set; }
        [Column("PermissionId")]
        public int PermissionId { get; set; }
        public Permission Permission { get; set; }

    }
}
