using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using medical.ServiceContract.services;
using Medical.DataTransferObjects.Location.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class LocationController : ApiController
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService, IMapper mapper) : base(mapper)
        {
            _locationService = locationService;
        }
        [HttpGet]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(GetLocationResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetLocationListAsync(
           CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _locationService.GetLocationListAsync(token);
                return new OkObjectResult(Mapper.Map<IEnumerable<GetLocationResponseDto>>(serviceResult));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpGet("{locationId}")]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(GetLocationResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetLocationByIdAsync(
            [FromRoute] int locationId,
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _locationService.GetLocationByIdAsync(locationId, token);
                return new OkObjectResult(Mapper.Map<GetLocationResponseDto>(serviceResult));
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }
    }
}