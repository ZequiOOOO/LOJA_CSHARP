namespace ProJeto_Cliente_Produto.Models
{
    public class Produto
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string? Descricao { get; set; }

        public decimal Preco { get; set; }

        public int Estoque { get; set; } = 0;

        public DateTime DataAdicionado { get; set; }
    }
}
