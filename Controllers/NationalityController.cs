using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using medical.ServiceContract.services;
using Medical.DataTransferObjects.Nationality.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class NationalityController : ApiController
    {
        private readonly INationalityService _nationalityService;

        public NationalityController(INationalityService nationalityService, IMapper mapper) : base(mapper)
        {
            _nationalityService = nationalityService;
        }
        [HttpGet]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(GetNationalityResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetNationalityListAsync(
           CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _nationalityService.GetNationalityListAsync(token);
                return new OkObjectResult(Mapper.Map<IEnumerable<GetNationalityResponseDto>>(serviceResult));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpGet("{nationalityId}")]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(GetNationalityResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetnationalityByIdAsync(
            [FromRoute] int nationalityId,
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _nationalityService.GetNationalityByIdAsync(nationalityId, token);
                return new OkObjectResult(Mapper.Map<GetNationalityResponseDto>(serviceResult));
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }
    }
}