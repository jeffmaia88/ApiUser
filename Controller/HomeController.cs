using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet("health-check")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
