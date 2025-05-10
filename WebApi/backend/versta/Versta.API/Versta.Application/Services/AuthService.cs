using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Versta.Core.Models;
using Versta.Core.Abstractions;
using Versta.DataAccess;
using Versta.DataAccess.Repo;
using Versta.DataAccess.Entities;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Web;
using BCrypt.Net;
using Microsoft.Extensions.Configuration;





namespace Versta.Application.Services
{
    using BCrypt.Net;
    using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http2;
    using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

    public class AuthService : IAuthService
    {
        private readonly VerstaDbContext _dbContext;
        private readonly IConfiguration _configuration;
        //private readonly IAccountRepo _accountRepo;
        public AuthService(VerstaDbContext dbContext, 
                            IConfiguration configuration)
                            //IAccountRepo accountRepo)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            //_accountRepo = accountRepo;
        }


        public async Task<User> Register(string email, string password,
            string username, string role)    // Task<User>
        {
            var hashedPassword = BCrypt.HashPassword(password);
            UserEntity userEntity = new UserEntity
            {
                Id = new Guid(),
                UserName = username,
                Password = hashedPassword,
                Email = email,
                Role = role
            };
            _dbContext.Users.Add(userEntity!);
            await _dbContext.SaveChangesAsync();

            User user = new User(email, hashedPassword);
            user.Id = userEntity.Id;
            user.UserName = userEntity.UserName;
            user.Role = userEntity.Role;
            return user;
        }


        public async Task<User> Login(string email, string password)
        {
            UserEntity userEntity = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);// && u.Password == password);
            //Person? person = people.FirstOrDefault(p => p.Email == loginData.Email && p.Password == loginData.Password);
            // if login is wrong                                                                                                 // if login is wrong
            if (userEntity == null)
            {
                return null;
            }
            User user = new User(email, password); 
            // if password is wrong
            if (user == null || BCrypt.Verify(password, userEntity.Password) == false)  
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
                        new Claim(ClaimTypes.Name, user.UserName!),
                        //new Claim(ClaimTypes.Id, id),
                        new Claim(ClaimTypes.Role, user.Role!)
                }),
                IssuedAt = DateTime.UtcNow,
                Issuer = _configuration["JWT:Issuer"],
                Audience = _configuration["JWT:Audience"],
                Expires = DateTime.UtcNow.AddHours(24),  //_configuration["JWT:Expires"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            //
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.IsActive = true;
            user.Id = userEntity.Id;
            user.Password = userEntity.Password;
            user.UserName = userEntity.UserName;
            user.Role = userEntity.Role;
            return user;
        }
    }
}

