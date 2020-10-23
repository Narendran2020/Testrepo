using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using medical.Common.Exceptions;
using medical.ServiceContract.ServiceObjects;
using medical.ServiceContract.services;
using Medical.DataTransferObjects.SmsSetting.Request;
using Medical.DataTransferObjects.SmsSetting.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class SmsSettingController : ApiController
    {
        private readonly ISmsSettingService _smsSettingService;
        public SmsSettingController(ISmsSettingService smsSettingService, IMapper mapper) : base(mapper)
        {
            _smsSettingService = smsSettingService;
        }
        [HttpPost]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(201, Type = typeof(AddSmsSettingResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateSmsSettingAsync(
          [FromBody] AddSmsSettingRequestDto addSmsSettingRequestDto,
          CancellationToken token = default)
        {
            try
            {
                var smsSettingServiceObject = Mapper.Map<SmsSettingServiceObject>(addSmsSettingRequestDto);
                var serviceResult = await _smsSettingService.CreateSmsSettingAsync(smsSettingServiceObject, token);
                return new CreatedResult(string.Empty, Mapper.Map<AddSmsSettingResponseDto>(serviceResult));
            }
            catch (BadRequestException e)
            {
                return new BadRequestObjectResult(e.Error);
            }
        }


        [HttpGet]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(GetSmsSettingResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetSmsSettingListAsync(
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _smsSettingService.GetSmsSettingListAsync(token);
                return new OkObjectResult(Mapper.Map<IEnumerable<GetSmsSettingResponseDto>>(serviceResult));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpGet("{smsSettingId}")]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(GetSmsSettingResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetSmsSettingByIdAsync(
            [FromRoute] int smsSettingId,
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _smsSettingService.GetSmsSettingByIdAsync(smsSettingId, token);
                return new OkObjectResult(Mapper.Map<GetSmsSettingResponseDto>(serviceResult));
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }

        [HttpPut("{smsSettingId}")]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(UpdateSmsSettingResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateSmsSettingByIdAsync(
            [FromRoute] int smsSettingId,
            [FromBody] UpdateSmsSettingRequestDto updateSmsSettingRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var smsSettingServiceObject = Mapper.Map<SmsSettingServiceObject>(updateSmsSettingRequestDto);
                smsSettingServiceObject.Id = smsSettingId;
                var serviceResult = await _smsSettingService.UpdateSmsSettingByIdAsync(smsSettingServiceObject, token);
                return new OkObjectResult(Mapper.Map<UpdateSmsSettingResponseDto>(serviceResult));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpDelete("{smsSettingId}")]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteSmsSettingByIdAsync(
            [FromRoute] int smsSettingId,
            CancellationToken token = default)
        {
            try
            {
                await _smsSettingService.DeleteSmsSettingByIdAsync(smsSettingId, token);
                return new StatusCodeResult(204);
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }
    }
}