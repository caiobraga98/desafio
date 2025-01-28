using desafio.Model;

namespace desafio.Repository
{
    public interface IWalletRepository
    {
        Task<Wallet> CreateWallet(Wallet wallet);
        Task<Wallet> GetWalletById(int id);

        Task<List<Wallet>> GetAll();

        Task<Wallet> Remove(int id);

        Task<Wallet> Update(Wallet wallet);
    }
}
