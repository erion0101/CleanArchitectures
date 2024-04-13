

using Microsoft.EntityFrameworkCore;

public class ReservationsService : IReservationsService
{
     public readonly IRepository<Reservations> _repository;
    public ReservationsService(IRepository<Reservations> repository)
    {
        _repository = repository;
    }
    public async Task AddTshirt(ReservationsDTO dto, CancellationToken cancellationToken)
    {
        var cartmapping = ReservationsMapping.ToModel(dto);
        await _repository.Add(cartmapping);
        await _repository.SaveAsync(cancellationToken);
    }

    public async Task<IEnumerable<ReservationsDTO>> AllReservations(CancellationToken token)
    {
        var reservation = await _repository.GetAllReservations().ToListAsync(token);
        return ReservationsMapping.ToDTOs(reservation);
    }
}