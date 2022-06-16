using EnergyManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnergyManager.Infrastructure.Context
{
    public class EnergyManagerContext : DbContext
    {
        public EnergyManagerContext(DbContextOptions<EnergyManagerContext> options)
            : base(options) { }

        public DbSet<Meter> Meters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meter>().HasKey(m => m.Id);
            modelBuilder.Entity<Meter>().Property(m => m.Number)
                .HasMaxLength(50);
        }
    }
}
