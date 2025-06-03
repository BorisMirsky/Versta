using Versta.Core.Models;

namespace Versta.Core.Abstractions
{
    public interface IAccountsRepo
    {
        Task<User> Register(string email, string password, string username, string role);
        Task<User?> Login(string email, string password);
    }
}
