using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using medical.Common.Exceptions;
using medical.ServiceContract.ServiceObjects;
using medical.ServiceContract.services;
using Medical.DataTransferObjects.Slot.Request;
using Medical.DataTransferObjects.Slot.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class SlotController : ApiController
    {
        private readonly ISlotService _slotService;
        public SlotController(ISlotService slotService, IMapper mapper) : base(mapper)
        {
            _slotService = slotService;
        }
        [HttpPost]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(201, Type = typeof(AddSlotResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateSlotAsync(
          [FromBody] AddSlotRequestDto addSlotRequestDto,
          CancellationToken token = default)
        {
            try
            {
                var slotServiceObject = Mapper.Map<SlotServiceObject>(addSlotRequestDto);
                var serviceResult = await _slotService.CreateSlotAsync(slotServiceObject, token);
                return new CreatedResult(string.Empty, Mapper.Map<AddSlotResponseDto>(serviceResult));
            }
            catch (BadRequestException e)
            {
                return new BadRequestObjectResult(e.Error);
            }
        }


        [HttpGet]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(GetSlotResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetSlotListAsync(
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _slotService.GetSlotListAsync(token);
                foreach (var item in serviceResult)
                {
                    TimeSpan st = TimeSpan.Parse(item.StartTime);
                    item.StartTime = st.ToString(@"hh\:mm");
                    TimeSpan et = TimeSpan.Parse(item.EndTime);
                    item.EndTime = et.ToString(@"hh\:mm");
                }
                return new OkObjectResult(Mapper.Map<IEnumerable<GetSlotResponseDto>>(serviceResult));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpGet("{slotId}")]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(GetSlotResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetSlotByIdAsync(
            [FromRoute] int slotId,
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _slotService.GetSlotByIdAsync(slotId, token);
                TimeSpan st = TimeSpan.Parse(serviceResult.StartTime);
                serviceResult.StartTime = st.ToString(@"hh\:mm");
                TimeSpan et = TimeSpan.Parse(serviceResult.EndTime);
                serviceResult.EndTime = et.ToString(@"hh\:mm");
                return new OkObjectResult(Mapper.Map<GetSlotResponseDto>(serviceResult));
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }

        [HttpPut("{slotId}")]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(UpdateSlotResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateSlotByIdAsync(
            [FromRoute] int slotId,
            [FromBody] UpdateSlotRequestDto updateSlotRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var slotServiceObject = Mapper.Map<SlotServiceObject>(updateSlotRequestDto);
                slotServiceObject.Id = slotId;
                var serviceResult = await _slotService.UpdateSlotByIdAsync(slotServiceObject, token);
                return new OkObjectResult(Mapper.Map<UpdateSlotResponseDto>(serviceResult));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpDelete("{slotId}")]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteSlotByIdAsync(
            [FromRoute] int slotId,
            CancellationToken token = default)
        {
            try
            {
                await _slotService.DeleteSlotByIdAsync(slotId, token);
                return new StatusCodeResult(204);
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }
    }
}