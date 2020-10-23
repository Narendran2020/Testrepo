using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using medical.Common.Exceptions;
using medical.data;
using medical.ServiceContract.ServiceObjects;
using medical.ServiceContract.services;
using Medical.DataTransferObjects.ReSchedule.Request;
using Medical.DataTransferObjects.ReSchedule.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Medical.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class ReScheduleController : ApiController
    {
        private readonly IReScheduleService _reScheduleService;
        private readonly MedicalDbContext _dbContext;
        public ReScheduleController(IReScheduleService reScheduleService, MedicalDbContext dbContext , IMapper mapper) : base(mapper)
        {
            _reScheduleService = reScheduleService;
            _dbContext = dbContext;
        }
        [HttpPost]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(201, Type = typeof(AddReScheduleResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateReScheduleAsync(
          [FromBody] AddReScheduleRequestDto addReScheduleRequestDto,
          CancellationToken token = default)
        {
            try
            {
                DateTime dateTime = DateTime.ParseExact(addReScheduleRequestDto.ReScheduleSlot,
                                    "hh:mm tt", CultureInfo.InvariantCulture);
                TimeSpan span = dateTime.TimeOfDay;
                addReScheduleRequestDto.ReScheduleSlot = span.ToString();
                var slot1 = span;
                var slot = await _dbContext.ClinicianSlots
                .SingleAsync(x => x.Id == addReScheduleRequestDto.ExistingSlotID, token);
                slot.Status = true;
                await _dbContext.SaveChangesAsync(token);
                var newSlot = await _dbContext.ClinicianSlots
                .SingleAsync(x => x.Id == addReScheduleRequestDto.NewSlotID, token);
                newSlot.Status = false;
                await _dbContext.SaveChangesAsync(token);
                var appointment = await _dbContext.Appointments
                                     .SingleAsync(appointment => appointment.Id == addReScheduleRequestDto.AppointmentID, token);
                appointment.ClinicianSlotTransID = addReScheduleRequestDto.NewSlotID;
                appointment.PreferredSlot = slot1;
                appointment.PreferredBookingDate = addReScheduleRequestDto.RescheduledDate;
                await _dbContext.SaveChangesAsync(token);
                var reScheduleServiceObject = Mapper.Map<ReScheduleServiceObject>(addReScheduleRequestDto);
                var serviceResult = await _reScheduleService.CreateReScheduleAsync(reScheduleServiceObject, token);
                return new CreatedResult(string.Empty, Mapper.Map<AddReScheduleResponseDto>(serviceResult));
            }
            catch (BadRequestException e)
            {
                return new BadRequestObjectResult(e.Error);
            }
        }
    }
}