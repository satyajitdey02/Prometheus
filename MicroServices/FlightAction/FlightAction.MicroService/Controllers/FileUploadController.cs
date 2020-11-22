using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FlightAction.Core.Constants;
using FlightAction.Core.DTOs;
using FlightAction.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightAction.MicroService.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Authorize(Policy = "ApiUser")]
    [Route(Constants.Api.Routes.FlightAction.BaseRoute)]
    public class FileUploadController : ControllerBase
    {
        private readonly IFileUploadService _fileUploadService;
        private readonly ClaimsPrincipal _caller;


        public FileUploadController(IHttpContextAccessor httpContextAccessor, IFileUploadService fileUploadService)
        {
            _caller = httpContextAccessor.HttpContext.User;
            _fileUploadService = fileUploadService;
        }

        [HttpPost]
        [Route(Constants.Api.Routes.FlightAction.UploadFile)]
        public async Task<IActionResult> UploadFileAsync([FromBody] FileUploadDTO fileUploadDto)
        {
            var userId = _caller.Claims.Single(c => c.Type == "id");

            return Ok(await _fileUploadService.ProcessFileAsync(fileUploadDto));
        }
    }
}
