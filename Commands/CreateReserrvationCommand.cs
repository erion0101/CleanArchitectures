using MediatR;

namespace q.Commands
{
    public class CreateReserrvationCommand : IRequest<ReservationsDTO>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int CarId { get; set; }
        public CarsDTO Cars { get; set; }
        public CustomersDTO Customers { get; set; }
    }
}
