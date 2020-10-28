using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace FlightActionWebApi.Controllers
{
    [ApiController]
    [Route("api/flightAction")]
    public class FileUploadController : ControllerBase
    {
        //// GET api/flightAction
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new[] { "value1", "value2" };
        //}

        // GET api/flightAction/uploadFiles
        [HttpGet("uploadFiles")]
        public ActionResult<IEnumerable<string>> UploadFilesAsync()
        {
            return new[] { "Uploaded File 11", "Uploaded File 12" };
        }
    }
}
