using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TaskManagement.Core.Implements.Http;

namespace TaskManagement.Core.Infrastructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BaseApiController : ControllerBase
    {
        [NonAction]
        public virtual IActionResult JsonResponse(HttpResponse response, int statusCode = (int)HttpStatusCode.OK)
        {
            return StatusCode(statusCode, new { statusCode = response.StatusCode, response.Data, response.Paging, response.Message });
        }
       
    }
}
