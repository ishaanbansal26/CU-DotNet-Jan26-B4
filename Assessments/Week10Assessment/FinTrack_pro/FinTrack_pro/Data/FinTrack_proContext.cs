using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinTrack_pro.Models;

namespace FinTrack_pro.Data
{
    public class FinTrack_proContext : DbContext
    {
        public FinTrack_proContext (DbContextOptions<FinTrack_proContext> options)
            : base(options)
        {
        }

        public DbSet<FinTrack_pro.Models.Account> Account { get; set; } = default!;
        public DbSet<FinTrack_pro.Models.Transaction> Transaction { get; set; } = default!;
    }
}
