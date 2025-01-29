using System.Transactions;
using desafio.Data;
using desafio.Model;
using Microsoft.EntityFrameworkCore;

namespace desafio.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DataContext _context;
        public PaymentRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public async Task Create(Payment payment)
        {
            _context.Add(payment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Payment>> GetAll()
        {
            return await _context.Payments.ToListAsync();
        }

        public async Task<Payment> GetById(int id)
        {
            return await _context.Payments.FindAsync(id);
        }

        public async Task Remove(int id)
        {
            _context.Remove(id);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Payment payment)
        {
            _context.Update(payment);
            await _context.SaveChangesAsync();
        }
    }
}
