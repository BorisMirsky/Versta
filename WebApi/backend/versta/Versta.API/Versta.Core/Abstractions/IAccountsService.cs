using Versta.Core.Models; 


namespace Versta.Core.Abstractions
{
    public interface IAccountsService
    {
        Task<User?> LoginAccount(string username, string password);
        Task<User> RegisterAccount(string email, string password, string username, string role);  
    }
}
