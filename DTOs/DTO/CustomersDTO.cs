using MinimalAPi.DTOs.DTO;
using q.DTOs.DTO;

public class CustomersDTO
{
     public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int NrLetenjoftimit { get; set; }
    public string Phone { get; set; }
    public int AdressId { get; set; }
    public AdressDTO AdressDTO { get; set; }
    public int GenderId { get; set; }
    public GenderDTO GenderDTO { get; set; }
    public int RoleId { get; set; }
    public RoleDTO RoleDTO { get; set; }

}