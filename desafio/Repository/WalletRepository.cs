using desafio.Data;
using desafio.Model;
using Microsoft.EntityFrameworkCore;

namespace desafio.Repository
{
    public class WalletRepository : IWalletRepository
    {
        private readonly DataContext _context;
        public WalletRepository(DataContext context)
        {
            _context = context;
        }
        public async Task CreateWallet(Wallet wallet)
        {
            try{
                _context.Add(wallet);
                await _context.SaveChangesAsync();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }             
        }

        public async Task<List<Wallet>> GetAll()
        {
            return await _context.Wallets.ToListAsync();
        }

        public async Task<Wallet> GetWalletById(int id)
        {
            return await _context.Wallets.FindAsync(id);
        }

        public async Task Remove(int id)
        {
            _context.Wallets.Remove(await GetWalletById(id));
            _context.SaveChanges();
        }

        public async Task Update(Wallet wallet)
        {
            _context.Wallets.Update(wallet);
            await _context.SaveChangesAsync();
        }
    }
}
