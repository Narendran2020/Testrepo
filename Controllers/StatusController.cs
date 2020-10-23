using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using medical.Common.Exceptions;
using medical.ServiceContract.ServiceObjects;
using medical.ServiceContract.services;
using Medical.DataTransferObjects.Status.Request;
using Medical.DataTransferObjects.Status.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class StatusController : ApiController
    {
        private readonly IStatusService _statusService;
        public StatusController(IStatusService statusService, IMapper mapper) : base(mapper)
        {
            _statusService = statusService;
        }
        [HttpPost]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(201, Type = typeof(AddStatusResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateCountryAsync(
          [FromBody] AddStatusRequestDto addStatusRequestDto,
          CancellationToken token = default)
        {
            try
            {

                var statusServiceObject = Mapper.Map<StatusServiceObject>(addStatusRequestDto);
                var serviceResult = await _statusService.CreateStatusAsync(statusServiceObject, token);
                return new CreatedResult(string.Empty, Mapper.Map<AddStatusResponseDto>(serviceResult));
            }
            catch (BadRequestException e)
            {
                return new BadRequestObjectResult(e.Error);
            }
        }


        [HttpGet]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(GetStatusResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetStatusListAsync(
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _statusService.GetStatusListAsync(token);
                return new OkObjectResult(Mapper.Map<IEnumerable<GetStatusResponseDto>>(serviceResult));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpGet("{statusId}")]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(GetStatusResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetStatusByIdAsync(
            [FromRoute] int statusId,
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _statusService.GetStatusByIdAsync(statusId, token);
                return new OkObjectResult(Mapper.Map<GetStatusResponseDto>(serviceResult));
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }

        [HttpPut("{statusId}")]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(UpdateStatusResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateStatusByIdAsync(
            [FromRoute] int statusId,
            [FromBody] UpdateStatusRequestDto updateStatusRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var statusServiceObject = Mapper.Map<StatusServiceObject>(updateStatusRequestDto);
                statusServiceObject.Id = statusId;
                var serviceResult = await _statusService.UpdateStatusByIdAsync(statusServiceObject, token);
                return new OkObjectResult(Mapper.Map<UpdateStatusResponseDto>(serviceResult));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpDelete("{statusId}")]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteStatusByIdAsync(
            [FromRoute] int statusId,
            CancellationToken token = default)
        {
            try
            {
                await _statusService.DeleteStatusByIdAsync(statusId, token);
                return new StatusCodeResult(204);
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }
    }
}