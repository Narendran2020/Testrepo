using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using medical.Common.Exceptions;
using medical.ServiceContract.ServiceObjects;
using medical.ServiceContract.services;
using Medical.DataTransferObjects.Appointment_Prefix.Request;
using Medical.DataTransferObjects.Appointment_Prefix.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class AppointmentPrefixController : ApiController
    {
        private readonly IAppointmentPrefixService _appointmentPrefixService;
        public AppointmentPrefixController(IAppointmentPrefixService appointmentPrefixService, IMapper mapper) : base(mapper)
        {
            _appointmentPrefixService = appointmentPrefixService;
        }

        [HttpPost]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(201, Type = typeof(AddAppointmentPrefixResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateAppointmentPrefixAsync(
          [FromBody] AddAppointmentPrefixRequestDto addAppointmentPrefixRequestDto,
          CancellationToken token = default)
        {
            try
            {
                var appointmentPrefixServiceObject = Mapper.Map<AppointmentprefixServiceObject>(addAppointmentPrefixRequestDto);
                var serviceResult = await _appointmentPrefixService.CreateAppointmentPrefixAsync(appointmentPrefixServiceObject, token);
                return new CreatedResult(string.Empty, Mapper.Map<AddAppointmentPrefixResponseDto>(serviceResult));
            }
            catch (BadRequestException e)
            {
                return new BadRequestObjectResult(e.Error);
            }
        }


        [HttpGet]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(GetAppointmentPrefixResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAppointmentPrefixListAsync(
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _appointmentPrefixService.GetAppointmentPrefixListAsync(token);
                return new OkObjectResult(Mapper.Map<IEnumerable<GetAppointmentPrefixResponseDto>>(serviceResult));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpGet("{appointmentPrefixId}")]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(GetAppointmentPrefixResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAppointmentPrefixByIdAsync(
            [FromRoute] int appointmentPrefixId,
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _appointmentPrefixService.GetAppointmentPrefixByIdAsync(appointmentPrefixId, token);
                return new OkObjectResult(Mapper.Map<GetAppointmentPrefixResponseDto>(serviceResult));
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }

        [HttpPut("{appointmentPrefixId}")]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(UpdateAppointmentPrefixResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateAppointmentPrefixByIdAsync(
            [FromRoute] int appointmentPrefixId,
            [FromBody] UpdateAppointmentPrefixRequestDto updateAppointmentPrefixRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var appointmentPrefixServiceObject = Mapper.Map<AppointmentprefixServiceObject>(updateAppointmentPrefixRequestDto);
                appointmentPrefixServiceObject.Id = appointmentPrefixId;
                var serviceResult = await _appointmentPrefixService.UpdateAppointmentPrefixByIdAsync(appointmentPrefixServiceObject, token);
                return new OkObjectResult(Mapper.Map<UpdateAppointmentPrefixResponseDto>(serviceResult));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpDelete("{appointmentPrefixId}")]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteAppointmentPrefixByIdAsync(
            [FromRoute] int appointmentPrefixId,
            CancellationToken token = default)
        {
            try
            {
                await _appointmentPrefixService.DeleteAppointmentPrefixByIdAsync(appointmentPrefixId, token);
                return new StatusCodeResult(204);
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }
    }
}