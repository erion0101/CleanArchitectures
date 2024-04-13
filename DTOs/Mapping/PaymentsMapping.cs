public static class PaymentsMapping 
{
    public static Payments ToModel(PaymentsDTO payments)
    {
        return new Payments
        {
            Id = payments.Id,
            PaymentData = payments.PaymentData,
            ReservationId = payments.ReservationId
        };
    }
    public static PaymentsDTO ToDTO(Payments payments) => new()
    {
        Id = payments.Id,
        PaymentData = payments.PaymentData,
        ReservationId = payments.ReservationId
    };
    public static IEnumerable<PaymentsDTO> ToDTOs(this IEnumerable<Payments> payments) =>
        payments.Select(s => ToDTO(s));
}