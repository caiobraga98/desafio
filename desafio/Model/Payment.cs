using System.ComponentModel.DataAnnotations;

namespace desafio.Model
{
    public class Payment
    {
        [Key]
        public int Id { get; set; } // Chave primária
        public decimal Amount { get; set; } // Valor da transação
        public DateTime Date { get; set; } // Data da transação

        // Relacionamento com Wallet (carteira de origem)
        public int? FromWalletId { get; set; } // Chave estrangeira (opcional)
        public Wallet FromWallet { get; set; }

        // Relacionamento com Wallet (carteira de destino)
        public int? ToWalletId { get; set; } // Chave estrangeira (opcional)
        public Wallet ToWallet { get; set; }
    }
}
