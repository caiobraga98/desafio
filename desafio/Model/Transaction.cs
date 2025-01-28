using System.ComponentModel.DataAnnotations;

namespace desafio.Model
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public string FromUserId { get; set; }
        public string ToUserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
