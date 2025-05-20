using InvestmentCalc.Services.FinanceServices.Model;
using InvestmentCalc.Services.PropertyServices.Model;
using InvestmentCalc.Services.UserServices.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace InvestmentCalc.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Mortgage> Mortgages { get; set; }
        public DbSet<MortgagePayment> MortgagePayments { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Property>()
           .HasOne(p => p.User)
           .WithMany(u => u.Properties)
           .HasForeignKey(p => p.UserId)
           .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Mortgage>()
                .HasOne(m => m.Property)
                .WithOne(p => p.Mortgage)
                .HasForeignKey<Mortgage>(m => m.PropertyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MortgagePayment>()
                .HasOne(mp => mp.Mortgage)
                .WithMany(m => m.Payments)
                .HasForeignKey(mp => mp.MortgageId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Expense>()
                .HasOne(e => e.Property)
                .WithMany(p => p.Expenses)
                .HasForeignKey(e => e.PropertyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Income>()
                .HasOne(i => i.Property)
                .WithMany(p => p.Incomes)
                .HasForeignKey(i => i.PropertyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}