using System.Runtime.CompilerServices;
using CapstoneMiniProject.DTOs;
using CapstoneMiniProject.Exceptions;
using CapstoneMiniProject.Helpers;
using CapstoneMiniProject.Models;
using CapstoneMiniProject.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CapstoneMiniProject.WebAPIServices
{
    public class AccountServices : IAccountService
    {
        private IAccountRepository _accountRepository;

        public AccountServices(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<Account> AddAccount(CreateAccountDto dto)
        {
            if (string.IsNullOrEmpty(dto.Name) || dto.InitialDeposit < 1000)
                throw new BadRequestException("Please Enter Valid Details");

            var account = new Account
            {
                Name = dto.Name,
                Balance = dto.InitialDeposit
            };
            account.AccountNumber = AccountNumberGenerator.Generate(account.AccountId);
            await _accountRepository.AddAccount(account);
            return account;

        }

        public async Task<List<Account>> GetAccount()
        {
            return await _accountRepository.GetAccount();
        }

        public async Task<Account> GetAccountById(int id)
        {
            var x = await _accountRepository.GetAccountById(id);
            if (x == null)
                throw new NotFoundException("Account Not Found");
            return x;
        }

        public async Task RemoveAccount(int id)
        {
            var x = await _accountRepository.GetAccountById(id);
            if (x == null)
                throw new NotFoundException("Account Not Found. Unable to Remove");
            await _accountRepository.RemoveAccount(id);
        }

        public async Task<Account> UpdateAccount(int id,CreateAccountDto dto)
        {
            var account = await _accountRepository.GetAccountById(id);
            if (account == null)
                throw new NotFoundException("Account Not Found");

            if (string.IsNullOrEmpty(dto.Name))
                throw new BadRequestException("Name should not be empty");
            account.Name = dto.Name;
            account.Balance = dto.InitialDeposit;
            await _accountRepository.UpdateAccount(account);
            return account;
        }

        public async Task Deposit(TransactionDto dto)
        {
            if (dto.Amount <= 0)
                throw new BadRequestException("Amount must be greater than 0");

            var account = await _accountRepository.GetAccountById(dto.AccountId);

            if (account == null)
                throw new NotFoundException("Account not found");

            account.Balance += dto.Amount;
            await _accountRepository.UpdateAccount(account);
        }

        public async Task Withdraw(TransactionDto dto)
        {
            if (dto.Amount <= 0)
                throw new BadRequestException("Amount must be greater than 0");

            var account = await _accountRepository.GetAccountById(dto.AccountId);

            if (account == null)
                throw new NotFoundException("Account not found");

            if (account.Balance - dto.Amount < 1000)
                throw new BadRequestException("Minimum balance must be ₹1000");

            account.Balance -= dto.Amount;
            await _accountRepository.UpdateAccount(account);
        }
    }
}
