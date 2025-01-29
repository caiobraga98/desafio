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
                .HasOne(p => p.FromWallet) // Payment tem uma Wallet de origem
                .WithMany(w => w.Payments) // Wallet tem muitos Payments
                .HasForeignKey(p => p.FromWalletId) // Chave estrangeira
                .OnDelete(DeleteBehavior.Restrict); // Comportamento de exclusão

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.ToWallet) // Payment tem uma Wallet de destino
                .WithMany() // Wallet não tem uma propriedade de navegação inversa
                .HasForeignKey(p => p.ToWalletId) // Chave estrangeira
                .OnDelete(DeleteBehavior.Restrict); // Comportamento de exclusão

            // Seed data (opcional)
            modelBuilder.Entity<Wallet>().HasData(
                new Wallet { Id = 1, UserId = "user1", Balance = 1000 },
                new Wallet { Id = 2, UserId = "user2", Balance = 500 }
            );

            modelBuilder.Entity<Payment>().HasData(
                new Payment
                {
                    Id = 1,
                    Amount = 100,
                    FromWalletId = 1,
                    ToWalletId = 2
                },
                new Payment
                {
                    Id = 2,
                    Amount = 50,
                    FromWalletId = 2,
                    ToWalletId = 1
                }
            );
        }
    }

    }
