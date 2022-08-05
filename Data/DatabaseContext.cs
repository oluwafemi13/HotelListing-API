using Microsoft.EntityFrameworkCore;
using HotelListing_API.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using HotelListing_API.ConfigurationsAndMappings.Entities;

namespace HotelListing_API.Data
{
    public class DatabaseContext :IdentityDbContext<ApiUser>
    {
        public DatabaseContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Hotel> Hotels { get; set; }

        //overridden method for seeding data into the database
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new HotelConfiguration());
            builder.ApplyConfiguration(new CountryConfiguration());

            

        }


    }
}
