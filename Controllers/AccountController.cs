using AutoMapper;
using HotelListing_API.Data;
using HotelListing_API.Models;
using HotelListing_API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace HotelListing_API.Controllers
{
    public class AccountController: ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
       // private readonly SignInManager<ApiUser> _SignInManager;
        private readonly ILogger<AccountController> _logger;  
        private readonly IMapper _mapper;
        private readonly IAuthenticationManager _AuthenticationManager;


        public AccountController(UserManager<ApiUser> userManager, 
            //SignInManager<ApiUser> signInManager,
                                 ILogger<AccountController> logger, IMapper mapper, 
                                 IAuthenticationManager AuthenticationManager)
        {

            _userManager = userManager;
            //signin manager used for security purposes/ authentication
            //_SignInManager = signInManager;
            _logger = logger;
            _mapper = mapper;
            _AuthenticationManager = AuthenticationManager;
        }



        #region registration Endpoint
        //Registration Endpoint
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDTO userRegistrationDTO)
        {
            _logger.LogInformation($"Registration Attempt for {userRegistrationDTO.Email}");
            if (ModelState.IsValid)
            {
                try
                {
                    var user = _mapper.Map<ApiUser>(userRegistrationDTO);
                    //user.UserName = userRegistrationDTO.Email;
                    var result = await _userManager.CreateAsync(user, userRegistrationDTO.Password);

                    if (!result.Succeeded)
                    {
                        //get all errors and package them at once
                        foreach(var error in result.Errors)
                        {
                            ModelState.AddModelError(error.Code, error.Description);
                        }
                        return BadRequest("Failed Registration Attempt");
                    }
                    return Accepted();
                }catch (Exception ex)
                {

                    _logger.LogError(ex, $"Something Went Wrong in the {nameof(Register)}");
                    return Problem($"Something Went Wrong in the{nameof(Register)}", statusCode:500);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        #endregion







        #region login Endpoint
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userLoginDTO)
        {
            _logger.LogInformation($"Login Attempt for {userLoginDTO.Email}");
            if (ModelState.IsValid)
            {
                try
                {
                    //in user login, we are not mapping instead we are using the signinmanager to 
                    //validate details
                    /*var user = _mapper.Map<ApiUser>(userLoginDTO);
                    var result = await _userManager.CreateAsync(user);*/
                    //var result =await _SignInManager.PasswordSignInAsync(userLoginDTO.Email, userLoginDTO.Password, false, false);

                    if (!await _AuthenticationManager.ValidateUser(userLoginDTO))
                    {
                        return Unauthorized();
                    }
                    return Accepted(new {Token = await _AuthenticationManager.CreateToken()});
                }
                catch (Exception ex)
                {

                    _logger.LogError(ex, $"Something Went Wrong in the {nameof(Login)}");
                    return Problem($"Something Went Wrong in the{nameof(Login)}", statusCode: 500);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        #endregion

    }



}
