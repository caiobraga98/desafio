using Microsoft.EntityFrameworkCore;

namespace desafio.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Model.Transaction> Transactions { get; set; }
        public DbSet<Model.Wallet> Wallets { get; set; }
    }
}
