public interface ICarService
{
    Task<IEnumerable<CarsDTO>> AllCars(CancellationToken token);
    Task<CarsDTO> GetCarByID(int id, CancellationToken token);
    Task AddCars(CarsDTO dto, CancellationToken cancellationToken);
}