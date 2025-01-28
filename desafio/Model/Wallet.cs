using System.ComponentModel.DataAnnotations;

namespace desafio.Model
{
    public class Wallet
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public decimal Balance { get; set; }

    }
}
