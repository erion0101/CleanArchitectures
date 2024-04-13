using MediatR;
using q.Queries;

namespace q.Handlers
{
    public class GetALLCarsQueryHandlers : IRequestHandler<GetALLCarsQuery, IEnumerable<CarsDTO>>
    {
        private readonly ICarService _carService;

        public GetALLCarsQueryHandlers(ICarService carService)
        {
            _carService = carService;
        }
        public async Task<IEnumerable<CarsDTO>> Handle(GetALLCarsQuery request, CancellationToken cancellationToken)
        {
             var cars = await _carService.AllCars(cancellationToken);
             return cars;
        }
    }
}
