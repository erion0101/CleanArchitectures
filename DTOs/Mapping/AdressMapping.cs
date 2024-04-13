using MinimalAPi.DTOs.DTO;
using MinimalAPi.SQL.Model;

namespace MinimalAPi.DTOs.Mapping
{
    public static class AdressMapping
    {
        public static Adress ToModel(AdressDTO adress)
        {
            if (adress == null)
            {
                return null; // Or handle the null case appropriately
            }
            return new Adress
            {
               City = adress.City,
               StreetAddress = adress.StreetAddress,
              // ZipCode = adress.ZipCode,
            };
        }
        public static AdressDTO ToDTO(Adress adress)
        {
            if (adress == null)
            {
                return null; // Or handle the null case appropriately
            }
            return new AdressDTO
            {
                City = adress.City,
                StreetAddress = adress.StreetAddress,
                ZipCode = adress.ZipCode,
            };
        }
        public static IEnumerable<AdressDTO> ToDTOs(this IEnumerable<Adress> adress) =>
               adress.Select(s => ToDTO(s));
    }
}
