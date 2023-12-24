using MicroservicesArtuchecture.AuthApi.Contracts;
using MicroservicesArtuchecture.AuthApi.Contracts.Request;
using MicroservicesArtuchecture.AuthApi.Contracts.Response;
using MicroservicesArtuchecture.AuthApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using Utility.Contracts;

namespace MicroservicesArtuchecture.AuthApi.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<MessageContract<UserContract>> Register(RegisterRequestContract register)
        {
           return  await _authService.Register(register);
        }

        [HttpPost("login")]
        public async Task<MessageContract<LoginResponseContract>> Login(LoginRequestContract login)
        {
            return await _authService.Login(login);
        }

    }
}
