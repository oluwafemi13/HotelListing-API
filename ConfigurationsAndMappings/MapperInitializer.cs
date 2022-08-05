using AutoMapper;
using HotelListing_API.Data;
using HotelListing_API.Models;

namespace HotelListing_API.ConfigurationsAndMappings
{
    public class MapperInitializer:Profile
    {

        public MapperInitializer()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            CreateMap<Hotel, HotelDTO>().ReverseMap();
            CreateMap<Hotel, CreateHotelDTO>().ReverseMap();
            CreateMap<ApiUser, UserRegistrationDTO>().ReverseMap();
            CreateMap<ApiUser, UserLoginDTO>().ReverseMap();
            
        }
    }
}
