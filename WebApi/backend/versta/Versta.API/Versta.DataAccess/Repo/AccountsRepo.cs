using Microsoft.EntityFrameworkCore;
using Versta.Core.Models;
using Versta.Core.Abstractions;
using Versta.DataAccess.Scripts;
using Microsoft.Extensions.Configuration;



namespace Versta.DataAccess.Repo
{
    using BCrypt.Net;

    public class AccountsRepo(VerstaDbContext context, IConfiguration configuration) : IAccountsRepo
    {

        private readonly VerstaDbContext _context = context;

        private readonly IConfiguration _configuration  =configuration;

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
            User? userEntity = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            // if login is wrong                                                                                   
            if (userEntity == null)
            {
                return null;
            }
            // if password is wrong
            if (userEntity == null || BCrypt.Verify(password, userEntity.Password) == false)
            {
                return null;
            }
            JwtGenerator tokenInstance = new(_configuration); 
            string token = tokenInstance.CreateTokenDescriptor(email,
                                                userEntity.UserName!,
                                                userEntity.Rolename!);
            userEntity.Token = token; 
            userEntity.IsActive = true;
            return userEntity;
        }
    }
}
