using HotelListing_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing_API.ConfigurationsAndMappings.Entities
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
                new Hotel
                {
                    Id = 1,
                    HotelName = "FITT",
                    HotelAddress = " Lagos",
                    HotelRating = 2.0,
                    CountryId = 1,
                },
                new Hotel
                {
                    Id = 2,
                    HotelName = "Oriental Hotel",
                    HotelAddress = " Abuja",
                    HotelRating = 1.5,
                    CountryId = 1,
                },
                new Hotel
                {
                    Id = 3,
                    HotelName = "Eko Hotel",
                    HotelAddress = " Lagis Island",
                    HotelRating = 4.5,
                    CountryId = 1,
                },
                 new Hotel
                 {
                     Id = 4,
                     HotelName = "Manshak Hotels",
                     HotelAddress = " Abidjan",
                     HotelRating = 4.5,
                     CountryId = 8,
                 },
                new Hotel
                {
                    Id = 5,
                    HotelName = "Eko Hotel",
                    HotelAddress = " Lagis Island",
                    HotelRating = 4.5,
                    CountryId = 1,
                },
                 new Hotel
                 {
                     Id = 6,
                     HotelName = "Oriental Hotel",
                     HotelAddress = " Abuja",
                     HotelRating = 1.5,
                     CountryId = 1,
                 },
                new Hotel
                {
                    Id = 7,
                    HotelName = "Eko Hotel",
                    HotelAddress = " Lagis Island",
                    HotelRating = 4.5,
                    CountryId = 1,
                }
                );
        }
    }
}
