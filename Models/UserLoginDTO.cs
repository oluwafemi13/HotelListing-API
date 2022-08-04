using System.ComponentModel.DataAnnotations;

namespace HotelListing_API.Models
{
    public class UserLoginDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(13, ErrorMessage = "Your Password Must Not Be Less Than {2} and must not be More than {1}", MinimumLength = 10)]
        public string Password { get; set; }
    }
}
