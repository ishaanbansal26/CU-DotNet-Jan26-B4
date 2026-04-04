using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using CapstoneMiniProject.Data;
using CapstoneMiniProject.DTOs;
using CapstoneMiniProject.Exceptions;
using CapstoneMiniProject.Models;
using CapstoneMiniProject.WebAPIServices;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CapstoneMiniProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
            try
            {
                var account = await _accountService.GetAccountById(id);
                return account;
            }
            catch(NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // PUT: api/Account/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(int id, CreateAccountDto dto)
        {
            try
            {
                await _accountService.UpdateAccount(id, dto);
                return Ok($"Updated Account {id}");
            }
            catch(BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch(NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }


        // POST: api/Account
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount(CreateAccountDto dto)
        {
            try
            {
                var account = await _accountService.AddAccount(dto);
                return CreatedAtAction(nameof(GetAccount), new { id = account.AccountId }, account);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // DELETE: api/Account/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            try
            {
                var account = await _accountService.GetAccountById(id);
                await _accountService.RemoveAccount(account.AccountId);
                return Ok($"Deleted AccountID {account.AccountId}");
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
            
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw(TransactionDto dto)
        {
            try
            {
                await _accountService.Withdraw(dto);
                return Ok($"withdrawn {dto.Amount} in AccountID {dto.AccountId}");
            }
            catch(BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch(NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit(TransactionDto dto)
        {
            try
            {
                await _accountService.Deposit(dto);
                return Ok($"deposited {dto.Amount} in AccountID {dto.AccountId}");
            }
            catch(BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch(NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
