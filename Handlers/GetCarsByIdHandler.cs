using MediatR;
using Newtonsoft.Json.Linq;
using q.Queries;

namespace q.Handlers
{
    public class GetCarsByIdHandler : IRequestHandler<GetCarsByIdQuery, CarsDTO>
    {
        private readonly ICarService _carService;

        public GetCarsByIdHandler(ICarService carService)
        {
            _carService = carService;
        }

        public async Task<CarsDTO> Handle(GetCarsByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var carDTO = await _carService.GetCarByID(request.Id, cancellationToken);
                if (carDTO == null)return null;
                    else
                return carDTO;


                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                throw new Exception("Error to geting data from database");
            }
        }
    }
}
