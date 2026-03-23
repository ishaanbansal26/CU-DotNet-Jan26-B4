using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoanManagementAPI_with_DTO.Data;
using LoanManagementAPI_with_DTO.Models;
using LoanManagementAPI_with_DTO.DTOs.GET;
using LoanManagementAPI_with_DTO.DTOs.CREATE;
using LoanManagementAPI_with_DTO.DTOs.UPDATE;
using AutoMapper;

namespace LoanManagementAPI_with_DTO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly LoanManagementAPI_with_DTOContext _context;
        private readonly IMapper _mapper;

        public LoansController(LoanManagementAPI_with_DTOContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Loans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loan>>> GetLoan()
        {
            return await _context.Loan.ToListAsync();
        }

        // GET: api/Loans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetLoanDetails>> GetLoan(int id)
        {
            GetLoanDetails getLoanDetails = new GetLoanDetails();
            var loan = await _context.Loan.FindAsync(id);

            //_mapper.Map(loan,getLoanDetails)
            if (loan == null)
            {
                return NotFound();
            }
            getLoanDetails.Borrower = loan.BorrowerName;
            getLoanDetails.LoanAmount = loan.Amount;
            getLoanDetails.Months = loan.LoanTermMonths;
            getLoanDetails.IsSettled = loan.IsApproved;
            return getLoanDetails;
        }

        // PUT: api/Loans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoan(int id, UpdateLoan updateLoan)
        {
            var loan = await _context.Loan.FindAsync(id);

            if (loan == null)
                return NotFound();

            if(id!=updateLoan.id)
            {
                return BadRequest();
            }
            //_mapper.Map(updateLoan,loan);
            
            loan.BorrowerName = updateLoan.Borrower;
            loan.Amount = updateLoan.LoanAmount;
            loan.LoanTermMonths = updateLoan.Months;
            loan.IsApproved = updateLoan.IsSettled;

            //_context.Entry(loan).State = EntityState.Modified;
            //THis is used when the EF is not tracking the entity

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Loans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Loan>> PostLoan(AddLoan addloan)
        {
            //var x = new Loan
            //{
            //    BorrowerName = addloan.Borrower,
            //    Amount=addloan.LoanAmount,
            //    LoanTermMonths=addloan.Months,
            //    IsApproved=addloan.IsSettled

            //};
            var loan = _mapper.Map<Loan>(addloan);
            _context.Loan.Add(loan);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetLoan", new { id = loan.LoanId }, loan);
        }

        // DELETE: api/Loans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoan(int id)
        {
       
            var loan = await _context.Loan.FindAsync(id);
            if (loan == null)
            {
                return NotFound();
            }

            _context.Loan.Remove(loan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoanExists(int id)
        {
            return _context.Loan.Any(e => e.LoanId == id);
        }
    }
}
