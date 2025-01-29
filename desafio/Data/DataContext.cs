using Microsoft.EntityFrameworkCore;
using desafio.Model;

namespace desafio.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração do relacionamento entre Payment e Wallet
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.FromWallet)
                .WithMany(w => w.Payments)
                .HasForeignKey(p => p.FromWalletId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.ToWallet)
                .WithMany()
                .HasForeignKey(p => p.ToWalletId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed data para Wallet
            modelBuilder.Entity<Wallet>().HasData(
                new Wallet { Id = 1, UserId = "user1", Balance = 1000 },
                new Wallet { Id = 2, UserId = "user2", Balance = 500 }
            );

            // Seed data para Payment
            modelBuilder.Entity<Payment>().HasData(
                new Payment
                {
                    Id = 1,
                    Amount = 100,
                    Date = DateTime.UtcNow,
                    FromWalletId = 1, // Transferência da carteira 1 para a carteira 2
                    ToWalletId = 2
                },
                new Payment
                {
                    Id = 2,
                    Amount = 50,
                    Date = DateTime.UtcNow.AddDays(-1),
                    FromWalletId = 2, // Transferência da carteira 2 para a carteira 1
                    ToWalletId = 1
                }
            );
        }
    }
}