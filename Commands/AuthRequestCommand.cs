using MediatR;
using q.DTOs.DTO;

namespace q.Commands
{
    public class AuthRequestCommand : IRequest<TokenDTO>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
