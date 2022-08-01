using System.ComponentModel.DataAnnotations;

namespace HotelListing_API.Models
{
    public class CountryDTO:CreateCountryDTO
    {
            public int Id { get; set; }

       
        public IList<HotelDTO> Hotels { get; set; }

           
    }
}
