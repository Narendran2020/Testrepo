using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using medical.Common.Exceptions;
using medical.ServiceContract.ServiceObjects;
using medical.ServiceContract.services;
using Medical.DataTransferObjects.EmailSetting.Request;
using Medical.DataTransferObjects.EmailSetting.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class EmailSettingController : ApiController
    {
        private readonly IEmailSettingService _EmailSettingService;
        public EmailSettingController(IEmailSettingService EmailSettingService, IMapper mapper) : base(mapper)
        {
            _EmailSettingService = EmailSettingService;
        }
        [HttpPost]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(201, Type = typeof(AddEmailSettingResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateEmailSettingAsync(
          [FromBody] AddEmailSettingRequestDto addEmailSettingRequestDto,
          CancellationToken token = default)
        {
            try
            {
                var emailSettingServiceObject = Mapper.Map<EmailSettingServiceObject>(addEmailSettingRequestDto);
                var serviceResult = await _EmailSettingService.CreateEmailSettingAsync(emailSettingServiceObject, token);
                return new CreatedResult(string.Empty, Mapper.Map<AddEmailSettingResponseDto>(serviceResult));
            }
            catch (BadRequestException e)
            {
                return new BadRequestObjectResult(e.Error);
            }
        }


        [HttpGet]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(GetEmailSettingResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetEmailSettingListAsync(
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _EmailSettingService.GetEmailSettingListAsync(token);
                return new OkObjectResult(Mapper.Map<IEnumerable<GetEmailSettingResponseDto>>(serviceResult));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpGet("{emailSettingId}")]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(GetEmailSettingResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetEmailSettingByIdAsync(
            [FromRoute] int emailSettingId,
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _EmailSettingService.GetEmailSettingByIdAsync(emailSettingId, token);
                return new OkObjectResult(Mapper.Map<GetEmailSettingResponseDto>(serviceResult));
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }

        [HttpPut("{emailSettingId}")]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(UpdateEmailSettingResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateEmailSettingByIdAsync(
            [FromRoute] int emailSettingId,
            [FromBody] UpdateEmailSettingRequestDto updateEmailSettingRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var emailSettingServiceObject = Mapper.Map<EmailSettingServiceObject>(updateEmailSettingRequestDto);
                emailSettingServiceObject.Id = emailSettingId;
                var serviceResult = await _EmailSettingService.UpdateEmailSettingByIdAsync(emailSettingServiceObject, token);
                return new OkObjectResult(Mapper.Map<UpdateEmailSettingResponseDto>(serviceResult));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpDelete("{emailSettingId}")]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteEmailSettingByIdAsync(
            [FromRoute] int emailSettingId,
            CancellationToken token = default)
        {
            try
            {
                await _EmailSettingService.DeleteEmailSettingByIdAsync(emailSettingId, token);
                return new StatusCodeResult(204);
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }
    }
}