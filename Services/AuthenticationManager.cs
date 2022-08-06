using HotelListing_API.Data;
using HotelListing_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelListing_API.Services
{
    public class AuthenticationManager : IAuthenticationManager
    {

        private readonly UserManager<ApiUser> _userManager;
        private readonly IConfiguration _configuration;
        private ApiUser _user;
        

        public AuthenticationManager(UserManager<ApiUser> userManager, IConfiguration configuration)
        {

            _userManager = userManager;
            _configuration = configuration;
            
        }

        #region create token
        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredential();
            var claims = await GetClaims();
            var token = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion

        #region Generate token options
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("jwt");
            var expiration = DateTime.Now.AddHours(Convert.ToDouble(jwtSettings.GetSection("lifetime").Value));
            var token = new JwtSecurityToken(
                issuer: jwtSettings.GetSection("validIssuer").Value,
                claims: claims,
                expires: expiration,
                signingCredentials: signingCredentials
                );

            return token;
        }
        #endregion


        #region get claims
        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user.UserName)

            };
            var roles = await _userManager.GetRolesAsync(_user);

            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }
        #endregion

        #region get sign in credentials
        private SigningCredentials GetSigningCredential()
        {
            var key = Environment.GetEnvironmentVariable("KEY");
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        #endregion

        #region validate user
        public async Task<bool> ValidateUser(UserLoginDTO loginDTO)
        {
             _user = await _userManager.FindByNameAsync(loginDTO.Email);
            if (_user == null)
            {
                return false;
            }
            else
            {
                return await _userManager.CheckPasswordAsync(_user, loginDTO.Password);
            }
        }

        #endregion
    }
}
