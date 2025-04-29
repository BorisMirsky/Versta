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
        public Task<User> Login(string username, string password);
        public Task<User> Register(User user);
    }
}
