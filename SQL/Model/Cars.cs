using System.ComponentModel.DataAnnotations.Schema;

//[Table("Cars")]
[Table("Cars")]
public class Cars : BaseViewModel
{
    [Column("Brend")]
    public string? Brend { get; set; }
    [Column("Model")]
    public string? Model { get; set; }
    [Column("Year")]
    public string?  Year { get; set; }
    [Column("Color")]
    public string? Color { get; set; }
    [Column("PriceForDay")]
    public decimal PriceForDay { get; set; }
}