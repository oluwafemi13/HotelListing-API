using HotelListing_API.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HotelListing_API.ServicesExtension
{
    public static class ServiceExtension
    {

        //configuring the Identity Service
        public static void ConfigureIdentity(this IServiceCollection services)
        {

                var builder = services.AddIdentityCore<ApiUser>(q => q.User.RequireUniqueEmail =true);
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);
                builder.AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();
        }

        //configuring the JWT service

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration Configuration)
        {
            var jwtSettings = Configuration.GetSection("jwt");
            var key = Environment.GetEnvironmentVariable("KEY");

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        //this is to validate the issuer
                        ValidateIssuer = true,
                        //this is to check if the token has expired or not
                        ValidateLifetime = true,
                        //this is to validate the signing key--> my signing key was setup in the environment variable using cmd(admin) | setx KEY(keyname) "keyvalue" /m |
                        ValidateIssuerSigningKey = true,
                        //this is to get the value of the issuer from the appsettings
                        ValidIssuer = jwtSettings.GetSection("Issuer").Value,
                        //this is for encoding key value gotten from the environment variable
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                    };
                });
        }
            
    }
}
