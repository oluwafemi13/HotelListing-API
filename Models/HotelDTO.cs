using System.ComponentModel.DataAnnotations;

namespace HotelListing_API.Models
{
    public class HotelDTO:CreateHotelDTO
    {

        public int Id { get; set; }

        public CountryDTO Country { get; set; }


    }
}
