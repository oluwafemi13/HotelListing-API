﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing_API.ConfigurationsAndMappings.Entities
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(new IdentityRole
            {
                Name = "user",
                NormalizedName = "USER"
            },
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMINISTRATOR"
            }
            /*new IdentityRole {

                Name = "Admin",
                NormalizedName = "ADMINISTRATOR"
            }*/
            );
        }
    }
}
