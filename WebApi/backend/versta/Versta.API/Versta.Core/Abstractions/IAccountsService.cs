using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Versta.Core.Models; //.User;



namespace Versta.Core.Abstractions
{
    public interface IAccountsService
    {
        Task<User?> LoginAccount(string username, string password);
        Task<User> RegisterAccount(string email, string password, string username, string role);  
    }
}
