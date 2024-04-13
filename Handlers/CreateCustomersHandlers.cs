using MediatR;
using q.Commands;

namespace q.Handlers
{
    public class CreateCustomersHandlers : IRequestHandler<CreateCustomersCommand, CustomersDTO>
    {
        private readonly ICustomersService _customersService;

        public CreateCustomersHandlers(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        public async Task<CustomersDTO> Handle(CreateCustomersCommand request, CancellationToken cancellationToken)
        {
            try
            {
                CustomersDTO customersDTO = new CustomersDTO()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Password = request.Password,
                    NrLetenjoftimit = request.NrLetenjoftimit,
                    Phone = request.Phone,
                    AdressDTO = request.adress,
                    GenderId = request.GenderId,
                    RoleId = request.RoleId,
                };

                 await _customersService.RegisterCustomers(customersDTO, cancellationToken);
                return customersDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return (CustomersDTO)Results.BadRequest("Gabim gjatë kërkesës për automjetin.");
            }
        }
    }
}
