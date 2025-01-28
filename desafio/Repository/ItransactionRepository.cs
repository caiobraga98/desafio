using System.Transactions;

namespace desafio.Repository
{
    public interface ItransactionRepository
    {
         Task<Transaction> CreateTransaction(Transaction transaction);
         Task<Transaction> GetTransactionById(int id);
         Task<List<Transaction>> GetAll();
         Task<List<Transaction>> GetTransactionsByWalletId(int walletId);
         Task<Transaction> Remove(int id);
    }
}
