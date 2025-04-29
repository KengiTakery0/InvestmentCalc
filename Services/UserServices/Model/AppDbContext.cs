using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace InvestmentCalc.Services.UserServices.Model
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("YourConnectionStringHere");
        }
    }
}