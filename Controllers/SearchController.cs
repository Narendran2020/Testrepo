using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using medical.ServiceContract.ServiceObjects;
using medical.ServiceContract.services;
using Medical.DataTransferObjects.ClinicianSchedule.Request;
using Medical.DataTransferObjects.ClinicianSchedule.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class SearchController : ApiController
    {
        private readonly IClinicianScheduleService _clinicianScheduleService;
        public SearchController(
           IClinicianScheduleService clinicianScheduleService,
            IMapper mapper) : base(mapper)
        {
            _clinicianScheduleService = clinicianScheduleService;
        }
        //[HttpPost]
        //[EnableCors("CorsPolicy")]
        //[ProducesResponseType(200, Type = typeof(GetClinicianScheduleResponseDto))]
        //[ProducesResponseType(404)]
        //public async Task<IActionResult> GetClinicianScheduleListAsync(
        //    [FromBody] SearchClinicianScheduleDto searchClinicianScheduleDto,
        //    CancellationToken token = default)
        //{
        //    try
        //    {
        //        var searchClinicianScheduleServiceObject = Mapper.Map<SearchClinicianScheduleServiceObject>(searchClinicianScheduleDto);
        //        var serviceResult = await _clinicianScheduleService.GetClinicianScheduleByIdAsync(searchClinicianScheduleServiceObject, token);
        //        return new OkObjectResult(Mapper.Map<IEnumerable<GetClinicianScheduleResponseDto>>(serviceResult));
        //    }
        //    catch (Exception)
        //    {
        //        return new BadRequestResult();
        //    }
        //}
    }
}