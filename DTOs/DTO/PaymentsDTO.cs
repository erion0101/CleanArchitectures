public  class PaymentsDTO 
{
    public int Id { get; set; }
    public DateTime PaymentData { get; set; }
    public decimal Amount { get; set; }
    public int  ReservationId { get; set; }
    //public Reservations? Reservations { get; set; }

}