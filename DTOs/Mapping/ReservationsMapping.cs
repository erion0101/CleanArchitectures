public static class ReservationsMapping
{
     public static Reservations ToModel(ReservationsDTO reservations)
    {
        return new Reservations
        {
            Id = reservations.Id,
            StartDate = reservations.StartDate,
            EndDate = reservations.EndDate,
            TotalPrice = reservations.TotalPrice,
            CarId = reservations.CarId,
            Cars = CarsMapping.ToModel(reservations.Cars),
            CustomerId = reservations.CustomerId,
            Customers = CustomersMapping.ToModel(reservations.Customers)
        };
    }
    public static ReservationsDTO ToDTO(this Reservations reservations) => new()
    {
        Id = reservations.Id,
        StartDate = reservations.StartDate,
        EndDate = reservations.EndDate,
        TotalPrice = reservations.TotalPrice,
        CarId = reservations.CarId,
        CustomerId = reservations.CustomerId,
        Cars = CarsMapping.ToDTO(reservations.Cars),
        Customers = CustomersMapping.ToDTOForReservation(reservations.Customers)
    };
    public static IEnumerable<ReservationsDTO> ToDTOs(this IEnumerable<Reservations> reservations) =>
        reservations.Select(s => ToDTO(s));
    
}