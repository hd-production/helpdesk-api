using Microsoft.AspNetCore.Mvc;

namespace HdProduction.HelpDesk.Api.Controllers
{
    [Route("")]
    [ApiController, ApiVersionNeutral]
    public class HomeController : ControllerBase
    {
        [HttpGet("")]
        public string Index()
        {
            return "HdProduction.HelpDesk.Api is running";
        }
    }
}