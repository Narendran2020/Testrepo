using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using medical.Common.Exceptions;
using medical.ServiceContract.ServiceObjects;
using medical.ServiceContract.services;
using Medical.DataTransferObjects.ReSchedule.Request;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class CancelAppointmentController : ApiController
    {
        private readonly IReScheduleService _reScheduleService;
        public CancelAppointmentController(IReScheduleService reScheduleService, IMapper mapper) : base(mapper)
        {
            _reScheduleService = reScheduleService;
        }
        [HttpPost]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CancelAppointmentAsync(
          [FromBody] CancelAppointmentRequest cancelAppointmentRequest,
          CancellationToken token = default)
        {
            try
            {

                var cancelAppointmentServiceObject = Mapper.Map<CancelAppointmentServiceObject>(cancelAppointmentRequest);
                await _reScheduleService.CancelAppointmentAsync(cancelAppointmentServiceObject, token);
                return new StatusCodeResult(204);
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }
    }
}