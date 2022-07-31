using System.ComponentModel.DataAnnotations;

namespace HotelListing_API.Models
{
    public class CreateCountryDTO
    {

        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Length too Long")]
        public string CountryName { get; set; }

        [Required]
        [StringLength(maximumLength: 5, ErrorMessage = "Length too Long")]
        public string CountryShortName { get; set; }
    }
}
