using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalAPi.DTOs.DTO
{
    public class AdressDTO
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string StreetAddress { get; set; }
        public int ZipCode { get; set; }
    }
}
