using Versta.Core.Models;
using Versta.Core.Abstractions;



namespace Versta.Application.Services
{
    public class AccountsService : IAccountsService
    {

        private readonly IAccountsRepo _accountsRepo;

        public AccountsService(IAccountsRepo accountsRepo)
        {
            _accountsRepo = accountsRepo;
        }


        public async Task<User> RegisterAccount(string email, string password, string username, string rolename)    
        {
            return await _accountsRepo.Register(email, password, username, rolename);
        }


        public async Task<User?> LoginAccount(string email, string password)
        {
            return await _accountsRepo.Login(email, password);
        }
    }
}

