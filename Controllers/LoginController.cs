using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using medical.Common.Exceptions;
using medical.ServiceContract.ServiceObjects;
using medical.ServiceContract.services;
using Medical.DataTransferObjects.Login.Request;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class LoginController : ApiController
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService, IMapper mapper) : base(mapper)
        {
            _loginService = loginService;
        }
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(bool))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateLoginAsync(
           [FromBody] AddLoginRequestDto addLoginRequestDto,
           CancellationToken token = default)
        {
            try
            {

                var loginServiceObject = Mapper.Map<LoginServiceObject>(addLoginRequestDto);
                var serviceResult = await _loginService.CreateLoginAsync(loginServiceObject, token);
                return new CreatedResult(string.Empty, Mapper.Map<bool>(serviceResult));
            }
            catch (BadRequestException e)
            {
                return new BadRequestObjectResult(e.Error);
            }
        }
    }
}