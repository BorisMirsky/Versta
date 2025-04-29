using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Versta.Core.Models;
using Versta.Core.Abstractions;
using Versta.DataAccess;
using Versta.DataAccess.Entities;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;






namespace Versta.Application.Services
{
    using BCrypt.Net;

    using Microsoft.Extensions.Configuration;

    public class AuthService : IAuthService
    {
        private readonly VerstaDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public AuthService(VerstaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }


        public async Task<User> Login(string username, string password)
        {
            //UserEntity userEntity = await _dbContext.Users.FindAsync(password); // username);
            UserEntity userEntity = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == username);  //&& u.Password == password && 
            User user = new User(userEntity!.UserName, userEntity.Password);
                                 //userEntity.Name, userEntity.Role);
            if (user == null || BCrypt.Verify(password, user.Password) == false)
            {
                return null; 
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:SecretKey"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName!),
                    //new Claim(ClaimTypes.GivenName, user.Name!),
                    new Claim(ClaimTypes.Role, user.Role!)
                }),
                IssuedAt = DateTime.UtcNow,
                Issuer = _configuration["JWT:Issuer"],
                Audience = _configuration["JWT:Audience"],
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.IsActive = true;
            user.Id = userEntity.Id;                         

            return user;
        }

        public async Task<User> Register(User user)
        {
            user.Password = BCrypt.HashPassword(user.Password);
            //UserEntity userEntity = await _dbContext.Users.FindAsync(user.Id); 
            UserEntity userEntity = new UserEntity
            {
                Id = new Guid(),  //             (Guid)user.Id!,
                UserName = user.UserName!,
                Password = user.Password
            };
            _dbContext.Users.Add(userEntity!);
            await _dbContext.SaveChangesAsync();
            //user.Id = userEntity.Id;                         //   need?
            return user;
        }
    }
}
