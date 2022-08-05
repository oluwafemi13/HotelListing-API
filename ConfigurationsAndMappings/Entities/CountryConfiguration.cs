using HotelListing_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing_API.ConfigurationsAndMappings.Entities
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(

              new Country
              {
                  Id = 1,
                  CountryName = "Nigeria",
                  CountryShortName = "NG"
              },
              new Country
              {
                  Id = 2,
                  CountryName = "Ghana",
                  CountryShortName = "GH"
              },
              new Country
              {
                  Id = 3,
                  CountryName = "South Africa",
                  CountryShortName = "SA"
              },
              new Country
              {
                  Id = 4,
                  CountryName = "Netherlands",
                  CountryShortName = "ND"
              },
              new Country
              {
                  Id = 5,
                  CountryName = "Gabon",
                  CountryShortName = "GB"
              },
              new Country
              {
                  Id = 6,
                  CountryName = "Guinea",
                  CountryShortName = "GE"
              },
              new Country
              {
                  Id = 7,
                  CountryName = "England",
                  CountryShortName = "EN"
              },
              new Country
              {
                  Id = 8,
                  CountryName = "Ivory Coast",
                  CountryShortName = "IV"
              }

                );
        }
    }

}
