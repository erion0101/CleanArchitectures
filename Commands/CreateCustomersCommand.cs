using MediatR;
using MinimalAPi.DTOs.DTO;

namespace q.Commands
{
    public class CreateCustomersCommand : IRequest<CustomersDTO>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int NrLetenjoftimit { get; set; }
        public string Phone { get; set; }
        public AdressDTO adress { get; set; }
        public int GenderId { get; set; }
        public int RoleId { get; set; }
    }
}
