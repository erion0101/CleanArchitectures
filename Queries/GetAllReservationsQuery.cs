using MediatR;

namespace q.Queries
{
    public class GetAllReservationsQuery : IRequest<IEnumerable<ReservationsDTO>>
    {
    }
}
