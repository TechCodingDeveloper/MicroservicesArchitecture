using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicesArtuchecture.AuthApi.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register()
        {
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login()
        {
            return Ok();
        }

    }
}
