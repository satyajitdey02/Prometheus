using System.Threading.Tasks;
using FlightAction.Core.DTOs;
using FlightAction.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlightActionWebApi.Controllers
{
    [ApiController]
    [Route("api/flightAction")]
    public class FileUploadController : ControllerBase
    {
        private readonly IFileUploadService _fileUploadService;

        public FileUploadController(IFileUploadService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }

        // HttpPost api/flightAction/uploadFile
        [HttpPost("uploadFile")]
        public async Task<IActionResult> UploadFileAsync([FromBody] FileUploadDTO fileUploadDto)
        {
            return Ok(await _fileUploadService.UploadFileAsync(fileUploadDto));
        }
    }
}
