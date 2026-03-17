using CompanyCodesApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyCodesApi.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Enterprise> Enterprises { get; set; }
        public DbSet<Code> Codes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enterprise>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Gln).IsRequired();
                entity.Property(e => e.Nit).IsRequired(false);
            });

            modelBuilder.Entity<Code>(entity => 
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name).IsRequired();
                entity.Property(c => c.Description).IsRequired(false);
                entity.HasOne(c => c.Owner)
                .WithMany(e => e.Codes)
                .HasForeignKey(c => c.EnterpriseId)
                .IsRequired();

            });
        }
    }    
}
