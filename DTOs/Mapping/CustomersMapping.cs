
using MinimalAPi.DTOs.Mapping;
using MinimalAPi.SQL.Model;
using q.DTOs.Mapping;

public static class CustomersMapping
{
     public static Customers ToModel(CustomersDTO customers)
     {
        if(customers == null)
        {
            return null;
        }
        return new Customers
        {
            Id = customers.Id,
            FirstName = customers.FirstName,
            LastName = customers.LastName,
            Email = customers.Email,
            Password = customers.Password,
            Phone = customers.Phone,
            AdresaId = customers.AdressId,
            Adress = AdressMapping.ToModel(customers.AdressDTO),
            GenderId = customers.GenderId,
            Gender = GenderMapping.ToModel(customers.GenderDTO),
            RoleId = customers.RoleId,
            Role = RoleMapping.ToModel(customers.RoleDTO),
        };
    }
    public static CustomersDTO ToDTO(Customers customers)
    {
        if(customers == null)
        {
            return null;
        }
        return new CustomersDTO
        {
            Id = customers.Id,
            FirstName = customers.FirstName,
            LastName = customers.LastName,
            Email = customers.Email,
            Password = customers.Password,
            Phone = customers.Phone,
            AdressId = customers.AdresaId,
            AdressDTO = AdressMapping.ToDTO(customers.Adress),
            GenderId = customers.GenderId,
            GenderDTO = GenderMapping.ToDTO(customers.Gender),
            RoleId = customers.RoleId,
            RoleDTO = RoleMapping.ToDTO(customers.Role),
        };
    }
    public static CustomersDTO ToDTOForReservation(Customers customers) => new()
    {
        //Id = customers.Id,
        FirstName = customers.FirstName,
        LastName = customers.LastName,
        Email = customers.Email,
        Password = customers.Password,
        Phone = customers.Phone,
        AdressId = customers.AdresaId,
        AdressDTO = AdressMapping.ToDTO(customers.Adress),
        GenderId = customers.GenderId,
        GenderDTO = GenderMapping.ToDTO(customers.Gender),
        RoleId = customers.RoleId,
        RoleDTO = RoleMapping.ToDTO(customers.Role),
    };


    public static IEnumerable<CustomersDTO> ToDTOs(this IEnumerable<Customers> cars) =>
        cars.Select(s => ToDTO(s));
}
