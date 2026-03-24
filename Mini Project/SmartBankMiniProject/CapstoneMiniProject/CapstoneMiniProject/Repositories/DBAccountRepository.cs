using CapstoneMiniProject.Data;
using CapstoneMiniProject.Exceptions;
using CapstoneMiniProject.Helpers;
using CapstoneMiniProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CapstoneMiniProject.Repositories
{
    public class DBAccountRepository : IAccountRepository
    {
        private CapstoneMiniProjectContext _context;

        public DBAccountRepository(CapstoneMiniProjectContext context)
        {
            _context = context;
        }
        public async Task AddAccount(Account account)
        {
            await _context.Account.AddAsync(account);
            await _context.SaveChangesAsync();
            account.AccountNumber = AccountNumberGenerator.Generate(account.AccountId); 
            await _context.SaveChangesAsync();

        }

        public async Task<List<Account>> GetAccount()
        {
            return await _context.Account.ToListAsync();
        }

        public async Task<Account> GetAccountById(int id)
        {
            var x = await _context.Account.FindAsync(id);
            return x;
        }

        public async Task RemoveAccount(int id)
        {
            var x = await _context.Account.FindAsync(id);
            _context.Account.Remove(x);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAccount(Account account)
        {
            var existing = await _context.Account.FindAsync(account.AccountId);
            if (existing == null)
                throw new NotFoundException("Account Not Found");

            existing.Name = account.Name;
            existing.Balance = account.Balance;
            await _context.SaveChangesAsync();

        }

    }
}
