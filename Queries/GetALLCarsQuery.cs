using MediatR;

namespace q.Queries
{
    public class GetALLCarsQuery : IRequest<IEnumerable<CarsDTO>>
    {
    }
}
