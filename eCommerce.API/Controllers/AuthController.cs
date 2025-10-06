using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public AuthController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost("register")]
        public async Task<IActionResult>Register(RegisterRequest registerRequest)
        {
            if(registerRequest == null)
            {
                return BadRequest("Invalid register data");
            }
            AuthenticationResponse? response = await _usersService.Register(registerRequest);

            if (response == null || response.Success == false)
            {
                return BadRequest(response);

            }

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            if(loginRequest == null)
            {
                return BadRequest("Invalid login data");
            }
            AuthenticationResponse? response = await _usersService.Login(loginRequest);

            if(response == null || response.Success == false) {
                return Unauthorized(response); 
            }

            return Ok(response);
        }
    }
}
