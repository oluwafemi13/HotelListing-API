using System.ComponentModel.DataAnnotations;

namespace HotelListing_API.Models
{
    public class UserRegistrationDTO: UserLoginDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

       [Required]
        public string UserName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        /*[Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(13, ErrorMessage = "Your Password Must Not Be Less Than {2} and must not be More than {1}", MinimumLength =10)]
        public string Password { get; set; }*/
    }
}
