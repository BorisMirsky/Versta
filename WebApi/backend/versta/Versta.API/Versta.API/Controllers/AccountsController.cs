using Microsoft.AspNetCore.Mvc;
using Versta.Core.Models;
using Versta.Core.Abstractions;
using Versta.API.Contracts;
//using Versta.Business.AuthService.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Versta.Application.Services;


namespace Versta.API.Controllers
{
    [ApiController]
    [Route("[controller]")]  
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsService _accountsService;

        public AccountsController(IAccountsService accountsService)
        {
            _accountsService = accountsService;
        }


        [Route("Register")]
        [HttpPost]   
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
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

            User registeredUser = await _accountsService.RegisterAccount(request.Email, 
                                                                request.Password, 
                                                                request.UserName, 
                                                                request.Role);

            if (registeredUser != null)
            {
                return Ok(registeredUser);
            }

            return BadRequest(new { message = "User registration unsuccessful" });
        }


        [Route("Login")]
        [HttpPost]  
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (String.IsNullOrEmpty(request.Email))
            {
                return BadRequest(new { message = "Email address needs to entered" });
            }
            else if (String.IsNullOrEmpty(request.Password))
            {
                return BadRequest(new { message = "Password needs to entered" });
            }

            User? loggedInUser = await _accountsService.LoginAccount(request.Email, request.Password);

            if (loggedInUser != null)
            {
                return Ok(loggedInUser);
            }

            return BadRequest(new { message = "User login unsuccessful" });
        }



        [Route("Logout")]
        [HttpPost]  
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            Response.Headers.Remove("Authorization");
            return Ok();
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


