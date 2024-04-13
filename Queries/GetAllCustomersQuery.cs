using MediatR;

namespace q.Queries
{
    public class GetAllCustomersQuery : IRequest<IEnumerable<CustomersDTO>>
    {

    }
}
