using HotelListing_API.Data;
using Microsoft.AspNetCore.Identity;

namespace HotelListing_API.ServicesExtension
{
    public static class ServiceExtension
    {

        public static void ConfigureIdentity(this IServiceCollection services)
        {

                var builder = services.AddIdentityCore<ApiUser>(q => q.User.RequireUniqueEmail =true);
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);
                builder.AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();
        }

        
    }
}
