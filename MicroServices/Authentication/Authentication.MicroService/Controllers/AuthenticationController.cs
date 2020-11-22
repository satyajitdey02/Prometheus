using System.Threading.Tasks;
using Authentication.Core.Constants;
using Authentication.Core.DTOs;
using Authentication.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.MicroService.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route(Constants.Api.Routes.Authentication.BaseRoute)]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route(Constants.Api.Routes.Authentication.Authenticate)]
        public async Task<IActionResult> AuthenticateAsync([FromBody] AuthenticateRequestDTO dto)
        {
            return Ok(await _authenticationService.AuthenticationAsync(dto));
        }
    }
}
