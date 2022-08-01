using AutoMapper;
using HotelListing_API.Data;
using HotelListing_API.Models;

namespace HotelListing_API.Mappings
{
    public class MapperInitializer:Profile
    {

        public MapperInitializer()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            CreateMap<Hotel, HotelDTO>().ReverseMap();
            CreateMap<Hotel, CreateHotelDTO>().ReverseMap();
            
        }
    }
}
