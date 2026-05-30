using Microsoft.EntityFrameworkCore;
using BankCashFlowManagement.Models;

namespace BankCashFlowManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Transfer> Transfers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(x => x.Balance)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Transaction>()
                .Property(x => x.Amount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Transfer>()
                .Property(x => x.Amount)
                .HasColumnType("decimal(18,2)");
        }

    }
}
