using System.ComponentModel.DataAnnotations;

namespace HotelListing_API.Models
{
    public class CreateHotelDTO
    {

        [Required]
        [StringLength(40, ErrorMessage = "Name Too Long")]
        public string HotelName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Address Too Long")]
        public string HotelAddress { get; set; }

        [Required]
        [Range(1, 5)]
        public double HotelRating { get; set; }

        [Required]
        public int CountryId { get; set; }

    }
}
