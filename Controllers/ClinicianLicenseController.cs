using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using medical.Common.Exceptions;
using medical.ServiceContract.ServiceObjects;
using medical.ServiceContract.services;
using Medical.DataTransferObjects.ClinicianLicense.Request;
using Medical.DataTransferObjects.ClinicianLicense.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class ClinicianLicenseController : ApiController
    {
        private readonly IClinicianLicenseService _clinicianlicenseService;
        public ClinicianLicenseController(IClinicianLicenseService clinicianLicenseService, IMapper mapper) : base(mapper)
        {
            _clinicianlicenseService = clinicianLicenseService;
        }
        [HttpGet]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(GetClinicianLicenseResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetClinicianLicenseListAsync(
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _clinicianlicenseService.GetClinicianLicenseListAsync(token);
                return new OkObjectResult(Mapper.Map<IEnumerable<GetClinicianLicenseResponseDto>>(serviceResult));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpPost]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(GetClinicianLicenseResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetClinicianLicenseByMedicalDepartmentAsync([FromBody] GetClinicianLicenseRequestDto clinicianLicenseRequestDto,CancellationToken token = default)
        {
            try
            {

                var clinicianServiceObject = Mapper.Map<ClinicianLicenseServiceObject>(clinicianLicenseRequestDto);
                var serviceResult = await _clinicianlicenseService.GetClinicianLicenseByDepartmentAsync(clinicianServiceObject, token);
                return new CreatedResult(string.Empty, Mapper.Map< IEnumerable < GetClinicianLicenseResponseDto >> (serviceResult));
            }
            catch (BadRequestException e)
            {
                return new BadRequestObjectResult(e.Error);
            }
        }


        [HttpGet("{facilityId}")]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(GetClinicianLicenseResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetClinicianLicenseByIdAsync(
           [FromRoute] int facilityId,
           CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _clinicianlicenseService.GetClinicianLicenseByIdAsync(facilityId, token);
                return new OkObjectResult(Mapper.Map<IEnumerable<GetClinicianLicenseResponseDto>>(serviceResult));
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }
    }
}