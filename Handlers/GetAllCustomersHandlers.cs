using MediatR;
using q.Queries;

namespace q.Handlers
{
    public class GetAllCustomersHandlers : IRequestHandler<GetAllCustomersQuery, IEnumerable<CustomersDTO>>
    {
        private readonly ICustomersService _customersService;

        public GetAllCustomersHandlers(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        public async Task<IEnumerable<CustomersDTO>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customersService.GetAllCustomers(cancellationToken);
            if (customer == null)
            {
                return new List<CustomersDTO>(); 
            }
            else
            {
                return customer; 
            }
        }
    }
}
