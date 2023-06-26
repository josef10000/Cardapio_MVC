namespace CardapioMVC.Models
{
    public class ItemPratoModel
    {
        public int Id { get; set; }

        public ProdutoModel Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
