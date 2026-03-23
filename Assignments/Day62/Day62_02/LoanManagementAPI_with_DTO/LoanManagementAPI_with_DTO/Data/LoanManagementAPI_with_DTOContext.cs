using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LoanManagementAPI_with_DTO.Models;

namespace LoanManagementAPI_with_DTO.Data
{
    public class LoanManagementAPI_with_DTOContext : DbContext
    {
        public LoanManagementAPI_with_DTOContext (DbContextOptions<LoanManagementAPI_with_DTOContext> options)
            : base(options)
        {
        }

        public DbSet<LoanManagementAPI_with_DTO.Models.Loan> Loan { get; set; } = default!;
    }
}
