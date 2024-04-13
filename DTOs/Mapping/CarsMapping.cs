public static class CarsMapping
{
    public static Cars ToModel(CarsDTO cars)
    {
        if(cars == null)
        {
            return null;
        }
        return new Cars
        {
            Id = cars.Id,
            Brend = cars.Brend,
            Model = cars.Model,
            Year = cars.Year,
            Color = cars.Color,
            PriceForDay = cars.PriceForDay
        };
    }
    public static CarsDTO ToDTO(Cars cars) => new()
    {
        Id = cars.Id,
        Brend = cars.Brend,
        Model = cars.Model,
        Year = cars.Year,
        Color = cars.Color,
        PriceForDay = cars.PriceForDay
    };
    public static IEnumerable<CarsDTO> ToDTOs(this IEnumerable<Cars> cars) =>
    cars.Select(s => ToDTO(s));
   
}