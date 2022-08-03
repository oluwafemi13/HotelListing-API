namespace HotelListing_API.Data
{
    public static class DatabaseInitializer
    {

        public static void Initialize(DatabaseContext context)
        {
            if (context.Countries.Any()) return;

            var country = new List<Country>
            {
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
               }
            };
            foreach(var Country in country)
            {
                context.Countries.Add(Country);

            }
           
            context.SaveChanges();

            var Hotel = new List<Hotel>
            {
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
               }

            };

            foreach (var hotel in Hotel)
            {
                context.Hotels.Add(hotel);

            }

            context.SaveChanges();


        }
    }
}
