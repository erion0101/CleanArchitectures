using MediatR;
using Newtonsoft.Json.Linq;
using q.Queries;

namespace q.Handlers
{
    public class GetAllReservationsHandlers : IRequestHandler<GetAllReservationsQuery, IEnumerable<ReservationsDTO>>
    {
        private readonly IReservationsService _reservationsService;

        public GetAllReservationsHandlers(IReservationsService reservationsService)
        {
            _reservationsService = reservationsService;
        }

        public async Task<IEnumerable<ReservationsDTO>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
        {
            var item = await _reservationsService.AllReservations(cancellationToken);
            return item;

        }
    }
}
