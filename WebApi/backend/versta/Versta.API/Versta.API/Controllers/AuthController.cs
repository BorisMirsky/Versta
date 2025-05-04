using Microsoft.AspNetCore.Mvc;
using Versta.Core.Models;
using Versta.Core.Abstractions;
using Versta.API.Contracts;
//using Versta.Business.AuthService.Interface;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;                     



namespace Versta.API.Controllers
{
    [ApiController]
    [Route("[controller]")]  //[action]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [Route("Register")]
        [AllowAnonymous]
        [HttpPost("auth/register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (String.IsNullOrEmpty(request.UserName))
            {
                return BadRequest(new { message = "User name needs to entered" });
            }
            else if (String.IsNullOrEmpty(request.Password))
            {
                return BadRequest(new { message = "Password needs to entered" });
            }

            User userToRegister = new(request.UserName, request.Password);

            User loggedInUser = await _authService.Register(request.UserName!, request.Password);

            if (loggedInUser != null)
            {
                return Ok(loggedInUser);
            }

            return BadRequest(new { message = "User registration unsuccessful" });
        }


        [Route("Login")]
        [AllowAnonymous]
        [HttpPost("auth/login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (String.IsNullOrEmpty(request.UserName))
            {
                return BadRequest(new { message = "Email address needs to entered" });
            }
            else if (String.IsNullOrEmpty(request.Password))
            {
                return BadRequest(new { message = "Password needs to entered" });
            }

            User loggedInUser = await _authService.Login(request.UserName, request.Password);

            if (loggedInUser != null)
            {
                return Ok(loggedInUser);
            }

            return BadRequest(new { message = "User login unsuccessful" });
        }



        [Authorize(Roles = "Everyone")]
        [HttpGet]
        public IActionResult Test()
        {
            string token = Request.Headers["Authorization"]!;

            if (token.StartsWith("Bearer"))
            {
                token = token.Substring("Bearer ".Length).Trim();
            }
            var handler = new JwtSecurityTokenHandler();

            JwtSecurityToken jwt = handler.ReadJwtToken(token);

            var claims = new Dictionary<string, string>();

            foreach (var claim in jwt.Claims)
            {
                claims.Add(claim.Type, claim.Value);
            }

            return Ok(claims);
        }
    }
}


// from register
//User registeredUser = await _authService.Register(userToRegister.UserName, userToRegister.Password);