using System.Transactions;
using desafio.Model;

namespace desafio.Repository
{
    public interface IPaymentRepository
    {
         Task Create(Payment payment);
         Task<Payment> GetById(int id);
         Task<List<Payment>> GetAll();
         Task Remove(int id);
         Task Update(Payment payment);


    }
}
