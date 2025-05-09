using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Versta.Core.Models; //.User;



namespace Versta.Core.Abstractions
{
    public interface IAuthService
    {
        Task<User> Login(string username, string password);
        Task<User> Register(string email, string password, string username, string role);  
    }
}
