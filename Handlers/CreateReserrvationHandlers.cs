using MediatR;
using q.Commands;

namespace q.Handlers
{
    public class CreateReserrvationHandlers : IRequestHandler<CreateReserrvationCommand, ReservationsDTO>
    {
        private readonly IReservationsService _reservationsService;
        public CreateReserrvationHandlers(IReservationsService reservationsService) 
        {
            _reservationsService = reservationsService;
        }

        public async Task<ReservationsDTO> Handle(CreateReserrvationCommand request, CancellationToken cancellationToken)
        {
            int numberOfDays = (int)request.EndDate.Subtract(request.StartDate).TotalDays;
            var priceforDay = request.Cars.PriceForDay;
            request.TotalPrice = priceforDay = numberOfDays;
            var item = request.TotalPrice;

            ReservationsDTO reservations = new ReservationsDTO
            { 
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                TotalPrice = item,
                CarId = request.CarId,
                Customers = request.Customers,
            };
            await _reservationsService.AddTshirt(reservations, cancellationToken);
            return reservations;
        }
    }
}
