using CapstoneMiniProject.Models;

namespace CapstoneMiniProject.Repositories
{
    public interface IAccountRepository
    {
        Task AddAccount(Account account);
        Task RemoveAccount(int id);
        Task<Account> GetAccountById(int id);
        Task<List<Account>> GetAccount();
        Task UpdateAccount(Account account);
    }
}
