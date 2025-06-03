using System.Text;
using System.Threading.Tasks;
using Versta.Core.Models;
using Versta.Core.Abstractions;
using Versta.DataAccess;
using Versta.DataAccess.Repo;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Web;
using BCrypt.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer; 



namespace Versta.Application.Services
{
    public class AccountsService : IAccountsService
    {

        private readonly IAccountsRepo _accountsRepo;

        public AccountsService(IAccountsRepo accountsRepo)
        {
            _accountsRepo = accountsRepo;
        }


        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<User> RegisterAccount(string email, string password, string username, string rolename)    
        {
            return await _accountsRepo.Register(email, password, username, rolename);
        }


        public async Task<User?> LoginAccount(string email, string password)
        {
            return await _accountsRepo.Login(email, password);
        }
    }
}

