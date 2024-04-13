using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalAPi.SQL.Model

{
    [Table("Gender")]
    public class Gender : BaseViewModel
    {
        [Column("GenderName")]
        public string GenderName { get; set; }

    }
}
