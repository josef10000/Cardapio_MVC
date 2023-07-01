namespace CardapioMVC.Models
{
    public class ItemPratoModel
    {
        public int ProdutoId { get; set; }
        public string ProdutoNome { get; set; }
        public double QuantidadeGramas { get; set; }
        public int Quantidade { get; set; }

        public int PratoId { get; set; } // Chave estrangeira
    }
}
