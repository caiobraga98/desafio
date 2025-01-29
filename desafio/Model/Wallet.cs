using System.ComponentModel.DataAnnotations;

namespace desafio.Model
{
    public class Wallet
    {
        [Key]
        public int Id { get; set; } // Chave primária
        public string UserId { get; set; } // Identificador do usuário
        public decimal Balance { get; set; } // Saldo da carteira

        // Relacionamento com Payment (lista de transações)
        public ICollection<Payment> Payments { get; set; }

    }
}
