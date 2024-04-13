using MinimalAPi.DTOs.DTO;
using MinimalAPi.SQL.Model;

namespace MinimalAPi.DTOs.Mapping
{
    public static class GenderMapping
    {
        public static Gender ToModel(GenderDTO gender)
        {
            if(gender == null)
            {
                return null;
            }
            return new Gender
            {
                GenderName = gender.GenderName
            };
        }
        public static GenderDTO ToDTO(Gender gender) 
        {
            if (gender == null)
            {
                return null;
            }
            return new GenderDTO
            {
                GenderName = gender.GenderName
            };
        }
        public static IEnumerable<GenderDTO> ToDTOs(this IEnumerable<Gender> gender) =>
               gender.Select(s => ToDTO(s));
    }
}
