using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using medical.Common.Exceptions;
using medical.ServiceContract.ServiceObjects;
using medical.ServiceContract.services;
using Medical.DataTransferObjects.Appointment.Request;
using Medical.DataTransferObjects.Appointment.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class AppointmentController : ApiController
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService, IMapper mapper) : base(mapper)
        {
            _appointmentService = appointmentService;
        }
        [HttpPost]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(201, Type = typeof(AddAppointmentResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateAppointmentAsync(
          [FromBody] AddAppointmentRequestDto addAppointmentRequestDto,
          CancellationToken token = default)
        {
            try
            {
                DateTime dateTime = DateTime.ParseExact(addAppointmentRequestDto.PreferredSlot,
                                    "hh:mm tt", CultureInfo.InvariantCulture);
                TimeSpan span = dateTime.TimeOfDay;
                addAppointmentRequestDto.PreferredSlot = span.ToString();
                var appointmentServiceObject = this.Mapper.Map<AppointmentServiceObject>(addAppointmentRequestDto);
                var serviceResult = await _appointmentService.CreateAppointmentAsync(appointmentServiceObject, token);
                return new CreatedResult(string.Empty, Mapper.Map<GetAppointmentResponseDto>(serviceResult));
            }
            catch (BadRequestException e)
            {
                return new BadRequestObjectResult(e.Error);
            }
        }


        [HttpGet]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(GetAppointmentResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAppointmentListAsync(
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _appointmentService.GetAppointmentListAsync(token);
                return new OkObjectResult(Mapper.Map<IEnumerable<GetAppointmentResponseDto>>(serviceResult));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpGet("{appointmentId}")]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(GetAppointmentResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAppointmentByIdAsync(
            [FromRoute] int appointmentId,
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _appointmentService.GetAppointmentByIdAsync(appointmentId, token);
                return new OkObjectResult(Mapper.Map<GetAppointmentResponseDto>(serviceResult));
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }

        [HttpPut("{appointmentId}")]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(UpdateAppointmentResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateAppointmentByIdAsync(
            [FromRoute] int appointmentId,
            [FromBody] UpdateAppointmentRequestDto updateAppointmentRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var appointmentServiceObject = Mapper.Map<AppointmentServiceObject>(updateAppointmentRequestDto);
                appointmentServiceObject.Id = appointmentId;
                var serviceResult = await _appointmentService.UpdateAppointmentByIdAsync(appointmentServiceObject, token);
                return new OkObjectResult(Mapper.Map<UpdateAppointmentResponseDto>(serviceResult));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpDelete("{appointmentId}")]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteAppointmentByIdAsync(
            [FromRoute] int appointmentId,
            CancellationToken token = default)
        {
            try
            {
                await _appointmentService.DeleteAppointmentByIdAsync(appointmentId, token);
                return new StatusCodeResult(204);
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }
    }
}