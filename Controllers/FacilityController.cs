using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using medical.ServiceContract.services;
using Medical.DataTransferObjects.Facility.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class FacilityController : ApiController
    {
        private readonly IFacilityService _facilityService;
        public FacilityController(IFacilityService facilityService, IMapper mapper) : base(mapper)
        {
            _facilityService = facilityService;
        }
        [HttpGet]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(GetFacilityResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetFacilityListAsync(
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _facilityService.GetFacilityListAsync(token);
                return new OkObjectResult(Mapper.Map<IEnumerable<GetFacilityResponseDto>>(serviceResult));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }
    }
}