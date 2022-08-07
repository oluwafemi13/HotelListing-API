using AutoMapper;
using HotelListing_API.Data;
using HotelListing_API.IRepository;
using HotelListing_API.Models;
using HotelListing_API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ILogger<HotelController> _logger;
        private readonly IWorkDone _Workdone;


        public HotelController(IMapper mapper, IWorkDone workdone, ILogger<HotelController> logger)
        {
                _mapper = mapper;
            _Workdone = workdone;
            _logger = logger;
        }


        //this is a get all method
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHotels()
        {
            try
            {
                var Hotels = await _Workdone.HotelRepository.GetAll();
                var results = _mapper.Map<IList<HotelDTO>>(Hotels);
                return Ok(results);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Broke in the {nameof(GetHotels)}");
                //statuscode 500 means internal server error
                return StatusCode(500, "Server Error, Try Again Later");
            }
        }

        [Authorize]
        [HttpGet("{id:int}", Name ="GetHotel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHotel(int id)
        {
            try
            {
                var Hotel = await _Workdone.HotelRepository.Get(q => q.Id == id, new List<string> { "Country"});
                var result = _mapper.Map<HotelDTO>(Hotel);
                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Broke in the {nameof(GetHotel)}");
                //statuscode 500 means internal server error
                return StatusCode(500, "Server Error, Try Again Later");
            }
        }


        [Authorize(Roles ="Administrator")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateHotel([FromBody]CreateHotelDTO createHoteldto)
        {

            if (ModelState.IsValid)
            {
                try
                {
                   var hotel = _mapper.Map<Hotel>(createHoteldto);
                    await _Workdone.HotelRepository.Insert(hotel);
                    await _Workdone.Save();

                    return CreatedAtRoute("GetHotel", new {id=hotel.Id}, hotel);
                }catch(Exception ex)
                {
                    _logger.LogError(ex, $"Something Went wrong in the {nameof(CreateHotel)}");
                    return StatusCode(500, "Internal Server Error. Please Try Again Later.");
                }
            }
            else
            {
                _logger.LogError($" Invalid Attempt in {nameof(CreateHotel)}");
                return BadRequest(ModelState); ;
            }

        }

        [Authorize]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateHotel([FromBody] CreateHotelDTO createHotelDTO)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var hotel = _mapper.Map<Hotel>(createHotelDTO);
                    _Workdone.HotelRepository.Update(hotel);
                    await _Workdone.Save();

                }
                catch(Exception ex)
                {

                }

            }
            else
            {

            }
        }

    }

   
}
