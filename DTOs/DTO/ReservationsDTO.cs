public class ReservationsDTO
{
   public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalPrice { get; set; }
    public int CarId { get; set; }
    public CarsDTO Cars { get; set; }
    public int CustomerId { get; set; }
   public CustomersDTO Customers { get; set; }
}