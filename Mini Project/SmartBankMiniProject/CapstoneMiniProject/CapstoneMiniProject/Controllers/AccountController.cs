using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CapstoneMiniProject.Data;
using CapstoneMiniProject.Models;
using CapstoneMiniProject.WebAPIServices;
using CapstoneMiniProject.DTOs;
using System.Xml;

namespace CapstoneMiniProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly CapstoneMiniProjectContext _context;
        private IAccountService _accountService;

        public AccountController(CapstoneMiniProjectContext context, IAccountService accountService)
        {
            _context = context;
            _accountService = accountService;
        }

        // GET: api/Account
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccount()
        {
            return await _accountService.GetAccount();
        }

        // GET: api/Account/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
            var account = await _accountService.GetAccountById(id);
            return account;
        }

        // PUT: api/Account/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(int id, CreateAccountDto dto)
        {
            await _accountService.UpdateAccount(id,dto);
            return NoContent();
        }


        // POST: api/Account
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount(CreateAccountDto dto)
        {
            var account = await _accountService.AddAccount(dto);
            return NoContent();
        }

        // DELETE: api/Account/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var account = await _accountService.GetAccountById(id);
            await _accountService.RemoveAccount(account.AccountId);
            return NoContent();
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw(TransactionDto dto)
        {
            await _accountService.Withdraw(dto);
            return NoContent();
        }
        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit(TransactionDto dto)
        {
            await _accountService.Deposit(dto);
            return NoContent();
        }
    }
}
