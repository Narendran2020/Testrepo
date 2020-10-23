using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using medical.ServiceContract.services;
using Medical.DataTransferObjects.Calender;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class CalendarController : ApiController
    {
        private readonly ICalendarService _calendarService;
        public CalendarController(ICalendarService calendarService, IMapper mapper) : base(mapper)
        {
            _calendarService = calendarService;
        }

        [HttpGet]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(GetCalenderResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCalendarListAsync(
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _calendarService.GetCalendarListAsync(token);
                return new OkObjectResult(Mapper.Map<IEnumerable<GetCalenderResponseDto>>(serviceResult));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }
    }
}