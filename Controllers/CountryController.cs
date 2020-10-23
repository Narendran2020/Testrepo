using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using medical.Common.Exceptions;
using medical.ServiceContract.ServiceObjects;
using medical.ServiceContract.services;
using Medical.DataTransferObjects.Country.Request;
using Medical.DataTransferObjects.Country.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class CountryController : ApiController
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService, IMapper mapper) : base(mapper)
        {
            _countryService = countryService;
        }
        

        [HttpGet]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(GetCountryResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCountryListAsync(
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _countryService.GetCountryListAsync(token);
                return new OkObjectResult(Mapper.Map<IEnumerable<GetCountryResponseDto>>(serviceResult));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpGet("{countryId}")]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(GetCountryResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCountryByIdAsync(
            [FromRoute] int countryId,
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _countryService.GetCountryByIdAsync(countryId, token);
                return new OkObjectResult(Mapper.Map<GetCountryResponseDto>(serviceResult));
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        } 
    }
}