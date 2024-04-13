public interface IReservationsService
{
      Task AddTshirt(ReservationsDTO dto, CancellationToken cancellationToken);
      Task<IEnumerable<ReservationsDTO>> AllReservations(CancellationToken token);
}