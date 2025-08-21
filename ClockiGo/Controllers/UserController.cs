using Microsoft.AspNetCore.Mvc;

namespace ClockiGo.Presentation.Controllers
{
    [Route("[controller]")]
    public class UserController : ApiController
    {
        [HttpGet]
        public IActionResult ListResource()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
