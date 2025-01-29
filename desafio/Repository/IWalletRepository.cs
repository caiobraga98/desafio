using desafio.Model;

namespace desafio.Repository
{
    public interface IWalletRepository
    {
        Task CreateWallet(Wallet wallet);
        Task<Wallet> GetWalletById(int id);

        Task<List<Wallet>> GetAll();

        Task Remove(int id);

        Task Update(Wallet wallet);
    }
}
