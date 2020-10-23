using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using medical.Common.Exceptions;
using medical.ServiceContract.ServiceObjects;
using medical.ServiceContract.services;
using Medical.DataTransferObjects.Sms;
using Medical.DataTransferObjects.Sms.Request;
using Medical.DataTransferObjects.Sms.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class SMSController : ApiController
    {
        private readonly ISmsService _smsService;
        public SMSController(ISmsService smsService, IMapper mapper) : base(mapper)
        {
            _smsService = smsService;
        }
        [HttpPost]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(201, Type = typeof(AddSmsResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateSmsAsync(
          [FromBody] AddSmsRequestDto addSmsRequestDto,
          CancellationToken token = default)
        {
            try
            {
                var smsServiceObject = Mapper.Map<SmsServiceObject>(addSmsRequestDto);
                var serviceResult = await _smsService.CreateSmsAsync(smsServiceObject, token);
                return new CreatedResult(string.Empty, Mapper.Map<AddSmsResponseDto>(serviceResult));
            }
            catch (BadRequestException e)
            {
                return new BadRequestObjectResult(e.Error);
            }
        }


        [HttpGet]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(GetSmsResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetSmsListAsync(
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _smsService.GetSmsListAsync(token);
                return new OkObjectResult(Mapper.Map<IEnumerable<GetSmsResponseDto>>(serviceResult));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpGet("{SmsId}")]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(GetSmsResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetSmsByIdAsync(
            [FromRoute] int SmsId,
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _smsService.GetSmsByIdAsync(SmsId, token);
                return new OkObjectResult(Mapper.Map<GetSmsResponseDto>(serviceResult));
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }

        [HttpPut("{SmsId}")]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(UpdateSmsResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateSmsByIdAsync(
            [FromRoute] int SmsId,
            [FromBody] UpdateSmsRequestDto updateSmsRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var SmsServiceObject = Mapper.Map<SmsServiceObject>(updateSmsRequestDto);
                SmsServiceObject.Id = SmsId;
                var serviceResult = await _smsService.UpdateSmsByIdAsync(SmsServiceObject, token);
                return new OkObjectResult(Mapper.Map<UpdateSmsResponseDto>(serviceResult));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpDelete("{SmsId}")]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteSmsByIdAsync(
            [FromRoute] int SmsId,
            CancellationToken token = default)
        {
            try
            {
                await _smsService.DeleteSmsByIdAsync(SmsId, token);
                return new StatusCodeResult(204);
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }
    }
}