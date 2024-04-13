using MediatR;

namespace q.Queries
{
    public class GetCarsByIdQuery : IRequest<CarsDTO>
    {
        public int Id { get;  }
        public GetCarsByIdQuery(int id)
        {
            Id = id;
        }
    }
}
