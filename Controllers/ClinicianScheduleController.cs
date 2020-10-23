using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using medical.Common.Exceptions;
using medical.data;
using medical.ServiceContract.ServiceObjects;
using medical.ServiceContract.services;
using Medical.DataContracts.Entities;
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
    public class ClinicianScheduleController : ApiController
    {
        private readonly IClinicianScheduleService _clinicianScheduleService;
        private ClinicianScheduleServiceObject serviceResult1;
        private readonly MedicalDbContext _dbContext;

        public ClinicianScheduleController(
            IClinicianScheduleService clinicianScheduleService, MedicalDbContext dbContext ,
             IMapper mapper) : base(mapper)
        {
            _clinicianScheduleService = clinicianScheduleService;
            _dbContext = dbContext;
        }
        [HttpPost]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(201, Type = typeof(AddClinicianScheduleResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateClinicianScheduleAsync(
             [FromBody] AddClinicianScheduleRequestDto addClinicianScheduleRequestDto,
             CancellationToken token = default)
        {
            try
            {
                var dates = new List<DateTime>();
                if (addClinicianScheduleRequestDto.ScheduledFor == 1)
                {
                    IEnumerable<int> SlotId = addClinicianScheduleRequestDto.SlotId;
                    foreach (var slots in SlotId)
                    {
                        if (_dbContext.ClinicianSchedules.FirstOrDefault(x => (x.FacilityID == addClinicianScheduleRequestDto.FacilityID && x.SlotID == slots && x.ScheduleDate == addClinicianScheduleRequestDto.ScheduleDate)) == null)
                        {

                            var serviceObject = new ClinicianScheduleServiceObject()
                            {
                                SlotID = slots,
                                CreatedBy = addClinicianScheduleRequestDto.CreatedBy,
                                FacilityID = addClinicianScheduleRequestDto.FacilityID,
                                ScheduleDate = addClinicianScheduleRequestDto.ScheduleDate,
                                ClinicianLicenseID = addClinicianScheduleRequestDto.ClinicianLicenseID,

                            };
                            serviceResult1 = await _clinicianScheduleService.CreateClinicianScheduleAsync(serviceObject, token);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    return new CreatedResult(string.Empty, Mapper.Map<AddClinicianScheduleResponseDto>(serviceResult1));

                }
                else if (addClinicianScheduleRequestDto.ScheduledFor == 2)
                {
                    DateTime date1 = addClinicianScheduleRequestDto.ScheduleDates.Begin;
                    DateTime date2 = addClinicianScheduleRequestDto.ScheduleDates.End;

                    for (var dt = date1; dt <= date2; dt = dt.AddDays(1))
                    {
                        dates.Add(dt);
                    }
                    
                    foreach (var items in dates)
                    {
                        IEnumerable<int> SlotId = addClinicianScheduleRequestDto.SlotId;
                        foreach (var slots in SlotId)
                        {
                            if (_dbContext.ClinicianSchedules.FirstOrDefault(x => (x.FacilityID == addClinicianScheduleRequestDto.FacilityID && x.SlotID == slots && x.ScheduleDate == addClinicianScheduleRequestDto.ScheduleDate)) == null)
                            {
                                var serviceObject = new ClinicianScheduleServiceObject()
                                {
                                    SlotID = slots,
                                    CreatedBy = addClinicianScheduleRequestDto.CreatedBy,
                                    FacilityID = addClinicianScheduleRequestDto.FacilityID,
                                    ScheduleDate = items,
                                    ClinicianLicenseID = addClinicianScheduleRequestDto.ClinicianLicenseID,

                                };
                                serviceResult1 = await _clinicianScheduleService.CreateClinicianScheduleAsync(serviceObject, token);
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }

                return new CreatedResult(string.Empty, Mapper.Map<AddClinicianScheduleResponseDto>(serviceResult1));

            }
            catch (BadRequestException e)
            {
                return new BadRequestObjectResult(e.Error);
            }
        }

        //[HttpPost("{Date}")]
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

        [HttpGet]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(GetClinicianScheduleResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetClinicianScheduleAsync(
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _clinicianScheduleService.GetClinicianScheduleAsync(token);
                return new OkObjectResult(Mapper.Map < IEnumerable<GetClinicianScheduleResponseDto>>(serviceResult));
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }

        [HttpPut("{clinicianScheduleId}")]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(UpdateClinicianScheduleResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateClinicianScheduleByIdAsync(
            [FromRoute] int clinicianScheduleId,
            [FromBody] UpdateClinicianScheduleRequestDto updateClinicianScheduleRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var clinicianScheduleServiceObject = Mapper.Map<ClinicianScheduleServiceObject>(updateClinicianScheduleRequestDto);
                clinicianScheduleServiceObject.Id = clinicianScheduleId;
                var serviceResult = await _clinicianScheduleService.UpdateClinicianScheduleByIdAsync(clinicianScheduleServiceObject, token);
                return new OkObjectResult(Mapper.Map<UpdateClinicianScheduleResponseDto>(serviceResult));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpDelete("{clinicianScheduleId}")]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteClinicianScheduleByIdAsync(
            [FromRoute] int clinicianScheduleId,
            CancellationToken token = default)
        {
            try
            {
                await _clinicianScheduleService.DeleteClinicianScheduleByIdAsync(clinicianScheduleId, token);
                return new StatusCodeResult(204);
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }
    }
}