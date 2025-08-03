using Microsoft.EntityFrameworkCore;
using BudgetTracker.Models;

namespace BudgetTracker.Data
{
    public class BudgetContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=budget.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Optional: Add default categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Food" },
                new Category { Id = 2, Name = "Utilities" },
                new Category { Id = 3, Name = "Transport" },
                new Category { Id = 4, Name = "Salary" }
            );
        }
    }
}
