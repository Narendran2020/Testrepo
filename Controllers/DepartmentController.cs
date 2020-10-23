using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using medical.ServiceContract.services;
using Medical.DataTransferObjects.Department.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class DepartmentController : ApiController
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService, IMapper mapper) : base(mapper)
        {
            _departmentService = departmentService;
        }
        [HttpGet]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(200, Type = typeof(GetDepartmentResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetDepartmentListAsync(
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _departmentService.GetDepartmentListAsync(token);
                return new OkObjectResult(Mapper.Map<IEnumerable<GetDepartmentResponseDto>>(serviceResult));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }
    }
}