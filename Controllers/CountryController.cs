using AutoMapper;
using HotelListing_API.Data;
using HotelListing_API.IRepository;
using HotelListing_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotelListing_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {

        private readonly IWorkDone _WorkDone;
        private readonly ILogger<CountryController> _Logger;
        private readonly IMapper _Mapper;

        public CountryController(IWorkDone WorkDone, ILogger<CountryController> Logger, IMapper mapper)
        {

            _WorkDone = WorkDone;
            _Logger = Logger;
            _Mapper = mapper;
        }


        //this is a get all method
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countries = await _WorkDone.countryRepository.GetAll();
                var results = _Mapper.Map<IList<CountryDTO>>(countries);
                return Ok(results);

            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, $"Something Broke in the {nameof(GetCountries)}");
                //statuscode 500 means internal server error
                return StatusCode(500, "Server Error, Try Again Later");
            }
        }

        //this is a get by id method

        [HttpGet("{id:int}", Name ="GetCountry")]
        public async Task<IActionResult> GetCountry(int id)
        {
            try
            {
                var country = await _WorkDone.countryRepository.Get(q => q.Id == id, new List<string> { "Hotels"});
                var result = _Mapper.Map<CountryDTO>(country);
                return Ok(result);

            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, $"Something Broke in the {nameof(GetCountry)}");
                //statuscode 500 means internal server error
                return StatusCode(500, "Server Error, Try Again Later");
            }
        }


        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCountry([FromBody] CreateCountryDTO createCountrydto)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var country = _Mapper.Map<Country>(createCountrydto);
                    await _WorkDone.countryRepository.Insert(country);
                    await _WorkDone.Save();

                    return CreatedAtRoute("GetCountry", new { id = country.Id }, country);
                }
                catch (Exception ex)
                {
                    _Logger.LogError(ex, $"Something Went wrong in the {nameof(CreateCountry)}");
                    return StatusCode(500, "Internal Server Error. Please Try Again Later.");
                }
            }
            else
            {
                _Logger.LogError($" Invalid Attempt in {nameof(CreateCountry)}");
                return BadRequest(ModelState); ;
            }

        }

    }
}
