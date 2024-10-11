using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabate.Clone.API.Errors;

namespace Talabate.Clone.API.Controllers
{
    [Route("Errors/{code}")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult Error(int code)
        {
            if (code == 404)
            {
                return NotFound(new ApiResponse(404 ,"Not Found End Point"));
            }
            else if (code == 500)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse(500, "Internal Server Error"));
            }

            // Handle other status codes if needed
            return StatusCode(code, new ApiResponse(code, "An error occurred"));
        }
    }
}
