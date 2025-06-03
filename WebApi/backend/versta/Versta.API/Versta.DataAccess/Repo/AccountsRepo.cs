using Microsoft.EntityFrameworkCore;
using Versta.Core.Models;
using Versta.Core.Abstractions;
//using System.Data.Entity;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Versta.DataAccess;
using Versta.DataAccess.Repo;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Web;
using BCrypt.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;



namespace Versta.DataAccess.Repo
{
    using BCrypt.Net;
    //using Microsoft.AspNetCore.Authorization;
    //using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

    public class AccountsRepo : IAccountsRepo
    {
        private readonly VerstaDbContext _context;
        private readonly IConfiguration _configuration;

        public AccountsRepo(VerstaDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<User> Register(string email, string password, string username, string role)
        {
            var hashedPassword = BCrypt.HashPassword(password);
            User userEntity = new User
            {
                Id = Guid.NewGuid(),
                UserName = username,
                Password = hashedPassword,
                Email = email,
                Rolename = role
            };
            _context.Users.Add(userEntity);
            await _context.SaveChangesAsync();
            return userEntity;
        }



        public async Task<User?> Login(string email, string password)
        {
            User? userEntity = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);// && u.Password == password);
            //Person? person = people.FirstOrDefault(p => p.Email == loginData.Email && p.Password == loginData.Password);
            // if login is wrong                                                                                                 // if login is wrong
            if (userEntity == null)
            {
                return null;
            }
            //User user = new User(email, password, userEntity.Rolename!);
            // if password is wrong
            if (userEntity == null || BCrypt.Verify(password, userEntity.Password) == false)
            {
                return null;
            }
            //
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:SecretKey"]!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim(ClaimTypes.Email, email),
                        new Claim(ClaimTypes.Name, userEntity.UserName!),
                        //new Claim(ClaimTypes.Id, id),
                        new Claim(ClaimTypes.Role, userEntity.Rolename!)
                }),
                IssuedAt = DateTime.UtcNow,
                Issuer = _configuration["JWT:Issuer"],
                Audience = _configuration["JWT:Audience"],
                Expires = DateTime.UtcNow.AddHours(24),  //_configuration["JWT:Expires"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            //
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return userEntity;
        }
    }
}
