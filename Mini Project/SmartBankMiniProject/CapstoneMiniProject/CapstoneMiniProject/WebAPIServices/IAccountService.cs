using CapstoneMiniProject.DTOs;
using CapstoneMiniProject.Models;

namespace CapstoneMiniProject.WebAPIServices
{
    public interface IAccountService
    {
        Task<Account> AddAccount(CreateAccountDto dto);
        Task RemoveAccount(int id);
        Task<Account> GetAccountById(int id);
        Task<List<Account>> GetAccount();

        Task<Account> UpdateAccount(int id,CreateAccountDto dto);

        Task Withdraw(TransactionDto dto);
        Task Deposit(TransactionDto dto);

    }
}
