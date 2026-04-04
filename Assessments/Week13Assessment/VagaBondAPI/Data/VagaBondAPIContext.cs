using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VagaBondAPI.Models;

namespace VagaBondAPI.Data
{
    public class VagaBondAPIContext : DbContext
    {
        public VagaBondAPIContext (DbContextOptions<VagaBondAPIContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Destination>().Property(x => x.CityName).IsRequired();
            modelBuilder.Entity<Destination>().Property(x => x.Country).IsRequired();
            modelBuilder.Entity<Destination>().Property(x => x.Description).HasMaxLength(200);
            modelBuilder.Entity<Destination>().Property(x => x.Rating).HasDefaultValue(3);
        }

        public DbSet<VagaBondAPI.Models.Destination> Destination { get; set; } = default!;
    }
}
