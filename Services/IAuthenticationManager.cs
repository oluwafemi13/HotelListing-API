using HotelListing_API.Models;

namespace HotelListing_API.Services
{
    public interface IAuthenticationManager
    {

        Task<bool> ValidateUser(UserLoginDTO loginDTO);

        Task<string> CreateToken();
    }
}
