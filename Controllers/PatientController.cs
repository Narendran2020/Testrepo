using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using medical.ServiceContract.services;
using Medical.DataTransferObjects.Patient.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("api/v1/[controller]/[action]")]
    [Produces("application/json")]
    public class PatientController : ApiController
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService, IMapper mapper) : base(mapper)
        {
            _patientService = patientService;
        }
        [HttpGet("{searchQuery}")]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(GetMRNResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetMRNListAsync([FromRoute] string searchQuery,
             CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _patientService.GetMRNListAsync(searchQuery,token);
                return new OkObjectResult(Mapper.Map<IEnumerable<GetMRNResponseDto>>(serviceResult));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpGet("{MRN}")]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(GetPatientResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetPatientByMRNAsync(
            [FromRoute] string MRN,
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _patientService.GetPatientByMRNAsync(MRN, token);
                return new OkObjectResult(Mapper.Map<GetPatientResponseDto>(serviceResult));
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }
    }
}