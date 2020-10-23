using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using medical.Common.Exceptions;
using medical.ServiceContract.services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class ConfirmationController : ApiController
    {
        private readonly IReScheduleService _reScheduleService;
        public ConfirmationController(IReScheduleService reScheduleService, IMapper mapper) : base(mapper)
        {
            _reScheduleService = reScheduleService;
        }
        [HttpGet("{appointmentScheduleId}")]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetSlotByIdAsync(
             [FromRoute] int appointmentScheduleId,
             CancellationToken token = default)
        {
            try
            {
                await _reScheduleService.ConfirmById(appointmentScheduleId, token);
                return new StatusCodeResult(204);
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }
    }
}