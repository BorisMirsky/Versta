//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Versta.Core.Models;
//using Versta.Core.Abstractions;
//using Versta.DataAccess;
//using Versta.DataAccess.Repo;
//using Versta.DataAccess.Entities;
//using Microsoft.IdentityModel.Tokens;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Http;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Web;
//using BCrypt.Net;
//using Microsoft.Extensions.Configuration;

//namespace Versta.Application.Account
//{
//    using BCrypt.Net;
//    using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http2;
//    using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

//    public class AccountOptions
//    {

//        public const tokenHandler = new JwtSecurityTokenHandler();
//        public const key = Encoding.ASCII.GetBytes(_configuration["JWT:SecretKey"]!);
//        public const tokenDescriptor = new SecurityTokenDescriptor
//        {
//            Subject = new ClaimsIdentity(new Claim[]
//            {
//                        new Claim(ClaimTypes.Name, username),
//                        //new Claim(ClaimTypes.Id, id),
//                        new Claim(ClaimTypes.Role, user.Role!)
//            }),
//            IssuedAt = DateTime.UtcNow,
//            Issuer = _configuration["JWT:Issuer"],
//            Audience = _configuration["JWT:Audience"],
//            Expires = DateTime.UtcNow.AddHours(24),  //_configuration["JWT:Expires"],
//            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
//        };
//        //
//        var token = tokenHandler.CreateToken(tokenDescriptor);
//    }
//}
