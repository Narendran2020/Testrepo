using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using medical.ServiceContract.ServiceObjects;
using medical.ServiceContract.services;
using Medical.DataTransferObjects.SeperatedSlot.Request;
using Medical.DataTransferObjects.SeperatedSlot.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class SeperatedSlotController : ApiController
    {
        private readonly ISeperatedSlotService _seperatedSlotService;
        public SeperatedSlotController(ISeperatedSlotService seperatedSlotService, IMapper mapper) : base(mapper)
        {
            _seperatedSlotService = seperatedSlotService;
        }
        [HttpPost]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(GetSeperatedSlotResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetSeperatedSlotListAsync(
            [FromBody] GetSeperatedSlotRequestDto getSeperatedSlotRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var getSeperatedSlotServiceObject = Mapper.Map<GetSeperatedSlotServiceObject>(getSeperatedSlotRequestDto);
                var serviceResult = await _seperatedSlotService.GetSeperatedSlotListAsync(getSeperatedSlotServiceObject, token);
                foreach (var item in serviceResult)
                {
                    TimeSpan timespan = TimeSpan.Parse(item.SlotTime);
                    DateTime time = DateTime.Today.Add(timespan);
                    item.SlotTime = time.ToString("hh:mm tt");
                }
                return new OkObjectResult(Mapper.Map<IEnumerable<GetSeperatedSlotResponseDto>>(serviceResult));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }
    }
}