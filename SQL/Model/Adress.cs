using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalAPi.SQL.Model
{
    [Table("Adress")]
    public class Adress : BaseViewModel
    {
        [Column("City")]
        public string City { get; set; }
        [Column("StreetAddress")]
        public string StreetAddress { get; set; }
        [Column("ZipCode")]
        public int ZipCode { get; set; }
    }
}
