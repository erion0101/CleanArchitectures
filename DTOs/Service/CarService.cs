
using Microsoft.EntityFrameworkCore;

public class CarService : ICarService
{
     public readonly IRepository<Cars> _repository;
    public CarService(IRepository<Cars> repository)
    {
        _repository = repository;
    }
    public async Task AddCars(CarsDTO dto, CancellationToken cancellationToken)
    {
        var carsmapping = CarsMapping.ToModel(dto);
        await _repository.Add(carsmapping);
        await _repository.SaveAsync(cancellationToken);
    }

    public async Task<IEnumerable<CarsDTO>> AllCars(CancellationToken token)
    {
        var cars = await _repository.GetAll().ToListAsync(token);
        return CarsMapping.ToDTOs(cars);
    }

    public async Task<CarsDTO?> GetCarByID(int id, CancellationToken token)
    {
        var cars = await _repository.Get(id, token);
        if (cars == null)
        {
            return null;
        }
        else
        {
            return CarsMapping.ToDTO(cars);
        }
    }
}