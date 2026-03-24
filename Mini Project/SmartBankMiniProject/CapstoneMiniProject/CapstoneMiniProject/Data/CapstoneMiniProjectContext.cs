using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CapstoneMiniProject.Models;

namespace CapstoneMiniProject.Data
{
    public class CapstoneMiniProjectContext : DbContext
    {
        public CapstoneMiniProjectContext (DbContextOptions<CapstoneMiniProjectContext> options)
            : base(options)
        {
        }

        public DbSet<CapstoneMiniProject.Models.Account> Account { get; set; } = default!;
    }
}
