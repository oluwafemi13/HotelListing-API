﻿using Microsoft.EntityFrameworkCore;
using HotelListing_API.Data;

namespace HotelListing_API.Data
{
    public class DatabaseContext :DbContext
    {
        public DatabaseContext(DbContextOptions options)
            :base(options)
        {

        }

        //overridden method for seeding data into the database
        public virtual void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
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
                );

            modelBuilder.Entity<Hotel>().HasData(
               new Hotel
               {
                   Id = 1,
                   HotelName = "FITT",
                   HotelAddress =" Lagos",
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
                );

        }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Hotel> Hotels { get; set; }
    }
}